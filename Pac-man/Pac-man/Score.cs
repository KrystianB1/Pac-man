using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Pac_man
{
    class Score : StateTemplate
    {
        private static String score = "Rank | SCORE";
        private Vector2 vec = Globals.spriteFontMenu.MeasureString(score);
        private Vector2 vec_for_line_score;
        private Vector2 vec_for_draw_score = new Vector2(300, 100);
        List<int> score_list = new List<int>();
        private static float default_position_score_Y = 0;
        private static float default_position_score_X = 0;
        private int count_score = 0;
        private int count_color = 0;
        private bool flaga = false;

        public Score()
        {
            load_score_from_file();
        }
        public override void Update(GameTime gameTime)
        {
            Draw();

        }
        public override void Draw()
        {
            default_position_score_Y = vec_for_draw_score.Y;
            default_position_score_X = vec_for_draw_score.X;
            Globals.spriteBatch.GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Begin();

            score_list.Sort();
            score_list.Reverse();
            Globals.spriteBatch.DrawString(Globals.spriteFontMenu, score, new Vector2(300 - vec.X / 2, 50), Globals.highLight);

            foreach (int s in score_list)
            {
                count_score++;

                if (flaga == false) vec_for_line_score = Globals.spriteFontMenu.MeasureString(s.ToString());

                vec_for_draw_score.X -= vec_for_line_score.X;
                Globals.spriteBatch.DrawString(Globals.spriteFontMenu, count_score + ".     " + s.ToString(), vec_for_draw_score, new Color(255,count_color,count_color));
                count_color += 50;
                vec_for_draw_score.X = default_position_score_X;
                vec_for_draw_score.Y += Globals.spriteFontMenu.LineSpacing + 2;

                if (count_score >= score_list.Count()) count_score = 0;

                flaga = true;
            }

            vec_for_draw_score.Y = default_position_score_Y;
            Globals.spriteBatch.End();
        }

        private void load_score_from_file()
        {

            try
            {
                using (StreamReader reader = new StreamReader("Content/score/score_save.txt"))
                {
                    int row = 0;

                    while (!reader.EndOfStream)
                    {
                        score_list.Add(Convert.ToInt32(reader.ReadLine()));

                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                throw new FileLoadException("Blad wczytywania pliku", e);
                Console.WriteLine(e.Message);
            }


        }
    }
}
