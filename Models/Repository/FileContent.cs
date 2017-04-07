using Game_classes_implement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Models;

namespace Game_classes_implement
{
    public class FileContent : IGameContext
    {

        Point pointResult;
        Point pointResult2;
        string celtype;
        string output;
        string error;

        public void SaveMap(Map map, string savefile)
        {
            try
            {
                foreach (Cell cell in map.cells)
                {
                    File.AppendAllText(savefile, cell.Index.ToString() + ";" + cell.Position.ToString() + ";" + cell.Type + ";" + System.Environment.NewLine);
                }
            }
            catch(System.ArgumentException e)
            {
                error = e.ToString();
            }
        }


        public Map LoadMap(string loadfile)
        {
            Cell[] cells = new Cell[81];

            for (int n = 0; n < cells.Length; n++)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(loadfile))
                    {
                        for (int i = -1; i < n; i++)
                        {
                            output = sr.ReadLine();
                        }


                        string[] gesplitst = output.Split(';');
                        string cellindex = gesplitst[0];

                        var g = Regex.Replace(cellindex, @"[\{\}a-zA-Z=]", "").Split(',');

                        pointResult = new Point(
                                     int.Parse(g[0]),
                                     int.Parse(g[1]));


                        string cellposition = gesplitst[1];

                        var d = Regex.Replace(cellposition, @"[\{\}a-zA-Z=]", "").Split(',');

                        pointResult2 = new Point(
                                     int.Parse(d[0]),
                                     int.Parse(d[1]));


                        celtype = gesplitst[2];


                        Size cellsize = new Size(33, 33);
                        cells[n] = new Cell(pointResult, pointResult2, cellsize);
                        if (celtype == "Normal")
                        {
                            cells[n].Type = Cell.CelType.Normal;
                        }
                        if (celtype == "Wall")
                        {
                            cells[n].Type = Cell.CelType.Wall;
                        }
                        if (celtype == "Goal")
                        {
                            cells[n].Type = Cell.CelType.Goal;
                        }
                        if (celtype == "health")
                        {
                            cells[n].Type = Cell.CelType.health;
                        }
                    }
                }
                catch (IOException e)
                {
                     error = e.ToString();
                    break;
                }
                
            }
            Size mapsize = new Size(300, 300);
            Size cellcount = new Size(9, 9);

            return new Map(mapsize, cellcount, cells);
        }
    }
}


