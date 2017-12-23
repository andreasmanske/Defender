using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Defender
{
    namespace Terrain
    {
        public class Mountains
        {
            private int GameAreaWidth;
            private int maxMapWidth;
            private int MaxMountainSectionHeight;
            private int MinMountainSectionHeight;
            private int MaxMountainSectionWidth;
            private int MinMountainSectionWidth;
            private Color MountainOutlineColor = Color.DarkGray;
            private const int maxHeightDifferentialBetweenSection= 40; // lower number makes it smoother while a higher number tends to produce more ragged mountains
            Random randomGenerator = new Random(); // keep an instance here otherwise you wind up getting the same number each time
            // sections will vary in width and height - more natural looking
            private class MountainSection
            {
                internal int startX;
                internal int startY;
                internal int endX;
                internal int endY;
                internal int width
                {
                    // read only property
                    get
                    {
                        return endX - startX;
                    }
                }
            }
            private List<MountainSection> MountainMap = new List<MountainSection>(); // keep the terrain in memory 
            private int MapWidth
            {
                get
                {
                    return MountainMap[MountainMap.Count - 1].endX;
                }
            }
            public Mountains(Form GameAreaForm, ref PictureBox TerrainArea)
            {
                maxMapWidth = 10000; // map extends beyond whats visible. once the end of the map is reached it repeats
                MinMountainSectionWidth = 25;
                MaxMountainSectionWidth = 100;
                MinMountainSectionHeight = 25;
                MaxMountainSectionHeight = TerrainArea.Height;
                TerrainArea.Width = maxMapWidth; // make it 100% of the lower part of the screen + 1 invisible section off the screen to the right
                GameAreaForm.Invalidate(); // update the graphics
                GameAreaWidth = TerrainArea.Width; // remember value for later            
                InitializeTerrain(); // put in memory
                GenerateTerrain(ref TerrainArea); // only a small part of the map will be visible as the terrain width exceeds the game area width
            }
            /// <summary>
            /// Puts the entire map of the mountain terrain in memory
            /// </summary>
            private void InitializeTerrain()
            {
                int currentWidth=0;
                while (currentWidth< maxMapWidth)
                {
                    MountainSection newPieceOfMountain = new MountainSection();
                    if (currentWidth == 0)
                    {
                        // start at the bottom left
                        newPieceOfMountain.startX = 0;
                        newPieceOfMountain.startY = MaxMountainSectionHeight;
                    }
                    else
                    {
                        newPieceOfMountain.startX = MountainMap[MountainMap.Count - 1].endX;
                        newPieceOfMountain.startY = MountainMap[MountainMap.Count - 1].endY;
                    }
                    // randomly generate a new piece of mountain
                    newPieceOfMountain.endX = newPieceOfMountain.startX + GetRandomNumber(MinMountainSectionWidth, MaxMountainSectionWidth);
                    newPieceOfMountain.endY = SmoothOutTerrain(newPieceOfMountain.startY, GetRandomNumber(MinMountainSectionHeight, MaxMountainSectionHeight));
                    MountainMap.Add(newPieceOfMountain);
                    currentWidth += newPieceOfMountain.width;
                }
            }
            public void RedrawLastVisibleSection(ref PictureBox TerrainArea, int screenWidth)
            {
                // get section that is within the visible screen but has parts outside the screen
                int left = Math.Abs(TerrainArea.Left);
                Pen myPen = new Pen(MountainOutlineColor, 2);
                Graphics p = TerrainArea.CreateGraphics();
                List<MountainSection> sectionsToRedraw = MountainMap.Where(map => map.startX <= (screenWidth + left-30) && map.endX >= (screenWidth + left-30)).ToList();
                foreach (MountainSection sectionToRedraw in sectionsToRedraw)
                {
                    p.DrawLine(myPen, sectionToRedraw.startX, sectionToRedraw.startY, sectionToRedraw.endX, sectionToRedraw.endY);
                }
            }
            private void GenerateTerrain(ref PictureBox TerrainArea)
            {
                int CurrentWidth = 0;
                int MountainSectionIndex = 0; 
                while (CurrentWidth < MapWidth)
                {
                    Pen myPen = new Pen(MountainOutlineColor, 2);
                    Graphics p = TerrainArea.CreateGraphics();
                    p.DrawLine(myPen, MountainMap[MountainSectionIndex].startX, MountainMap[MountainSectionIndex].startY, MountainMap[MountainSectionIndex].endX, MountainMap[MountainSectionIndex].endY);
                    CurrentWidth += MountainMap[MountainSectionIndex].width;
                    MountainSectionIndex += 1;
                    if (MountainSectionIndex > MountainMap.Count-1) break; // get out of the loop
                }
            }
            private int SmoothOutTerrain(int currentY, int newY)
            {
                if (Math.Abs(newY - currentY) < maxHeightDifferentialBetweenSection) return newY;
                if (newY < currentY) return currentY - maxHeightDifferentialBetweenSection;
                if (newY > currentY) return currentY + maxHeightDifferentialBetweenSection;
                return newY;
            }
            private int GetRandomNumber(int start, int end)
            {           
                return randomGenerator.Next(start, end);
            }
        }
    }
}
