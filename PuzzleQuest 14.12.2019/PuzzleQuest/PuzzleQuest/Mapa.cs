using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PuzzleQuest
{
    public partial class Mapa : Form
    {
       public static int y = 0;
       public static int x = 0;
        
        const int sizeCard = 80;
        const int rozmiar = 10;
        Button[,] karty = new Button[rozmiar, rozmiar];
        List<Image> droga = new List<Image>();
        List<Image> przeciwnicy_na_mapie = new List<Image>();
        List<Image> przeciwnicy_w_grze = new List<Image>();
        List<Image> bohater = new List<Image>();
        public Button rycerz = new Button();
        public Nowa_Gra p = new Nowa_Gra();

        
        

        
        
        public Mapa()
        {
            bohater.Add(global::PuzzleQuest.Properties.Resources.czarny_Rycerz);
            droga.Add(global::PuzzleQuest.Properties.Resources.Droga_prosta);
            droga.Add(global::PuzzleQuest.Properties.Resources.zakret_1);
            droga.Add(global::PuzzleQuest.Properties.Resources.zakret_2);
            droga.Add(global::PuzzleQuest.Properties.Resources.zakret_3);
            droga.Add(global::PuzzleQuest.Properties.Resources.zakret_4);

            przeciwnicy_na_mapie.Add(global::PuzzleQuest.Properties.Resources.belial_na_mapie);
            przeciwnicy_na_mapie.Add(global::PuzzleQuest.Properties.Resources.radament_na_mapie);
            przeciwnicy_na_mapie.Add(global::PuzzleQuest.Properties.Resources.mefisto_profilowe);
            przeciwnicy_na_mapie.Add(global::PuzzleQuest.Properties.Resources.Duriel_droga);
            przeciwnicy_na_mapie.Add(global::PuzzleQuest.Properties.Resources.Baal_droga);
            przeciwnicy_na_mapie.Add(global::PuzzleQuest.Properties.Resources.Tyrael_droga);


            przeciwnicy_w_grze.Add(global::PuzzleQuest.Properties.Resources.belial_przeciwnik);
            przeciwnicy_w_grze.Add(global::PuzzleQuest.Properties.Resources.radament_przeciwnik);
            przeciwnicy_w_grze.Add(global::PuzzleQuest.Properties.Resources.Mefisto_walka);
            przeciwnicy_w_grze.Add(global::PuzzleQuest.Properties.Resources.duriel_walka);
            przeciwnicy_w_grze.Add(global::PuzzleQuest.Properties.Resources.Baal_walka);
            przeciwnicy_w_grze.Add(global::PuzzleQuest.Properties.Resources.Tyrael_walka);



            InitializeComponent();
            
            rycerz.Location = new Point(x* sizeCard ,y * sizeCard);
            rycerz.Size = new Size(sizeCard, sizeCard);
            rycerz.BackgroundImage = bohater[0];
            rycerz.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Controls.Add(rycerz);
            rycerz.KeyPress += KeyPress_pressed;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Button b = new Button();
                    b.Location = new Point(x * sizeCard, y * sizeCard);
                    b.Size = new Size(sizeCard, sizeCard);
                    if(x == 0 && y == 7)
                    {
                        b.BackgroundImage = przeciwnicy_na_mapie[5];
                    }
                    else if (((y%2 == 0) && (x <= 6 && x >= 1)) || (x == 0 && y == 0) ||
                       ((y%2 == 1 || y == 7) && (x >= 1 && x <= 6)) || (x == 0 && y == 7))
                    {
                        b.BackgroundImage = droga[0];
                    }

                    else if (x == 7 && (y%2 == 0))
                    {
                        if (y == 0)
                        {
                            b.BackgroundImage = przeciwnicy_na_mapie[0]; //belial
                        }

                        else if(y == 6)
                        {
                            b.BackgroundImage = przeciwnicy_na_mapie[4]; //baal
                        }
                        else
                        {
                            b.BackgroundImage = droga[2];
                        }
                    }
                    else if (x == 7 && (y%2 == 1))
                    {
                        if (y == 3)
                        {
                            b.BackgroundImage = przeciwnicy_na_mapie[2]; //mefisto
                        }
                        
                        else
                        {
                            b.BackgroundImage = droga[1];
                        }
                    }
                    else if ((y%2 == 1) && x == 0)
                    {
                        if (y == 5)
                        {
                            b.BackgroundImage = przeciwnicy_na_mapie[3]; //duriel
                            b.BackgroundImageLayout = ImageLayout.Zoom;
                        }
                       
                        else
                        
                            b.BackgroundImage = droga[3];
                            b.BackgroundImageLayout = ImageLayout.Zoom;
                        
                    }
                    else if (x == 0 && (y%2 == 0))
                    {
                        if (x == 0 && y == 2)
                        {
                            b.BackgroundImage = przeciwnicy_na_mapie[1]; //radament
                        }
                      
                        else
                            b.BackgroundImage = droga[4];
                    }
                    

                  
                    b.BackgroundImageLayout = ImageLayout.Zoom; 
                    b.Tag = new Point(x, y);

                    

                    panel1.Location = new Point(450, 0);
                    panel1.Size = new Size(750, 800);
                    panel1.Controls.Add(b);
                    
                    karty[y, x] = b;
                    
                   b.KeyPress += KeyPress_pressed;
                    
                }
            }

            
            label_pokaz_login.Text = Logowanie.login;            
                

        }

        
        private void otworzInterface()
        {
            
            Application.Run(p);
        }


        

        private void Mapa_Load(object sender, EventArgs e)
        {

        }

        private void KeyPress_pressed(object sender, KeyPressEventArgs e)
        {
            
            if ((Keys)e.KeyChar == Keys.D || e.KeyChar == 'd')
            {
                if (y % 2 == 0 && x <= 6)
                {
                    x++;
                    Console.WriteLine("x = " + x);
                }
                rycerz.Location = new Point(x * sizeCard, y * sizeCard);

                if (rycerz.Location.X == karty[0,7].Location.X  
                    && rycerz.Location.Y == karty[0,7].Location.Y)
                {
                    przeciwnik_Beliar();
                }

                Console.WriteLine("x = " + rycerz.Location.X);
                Console.WriteLine("y = " + rycerz.Location.Y);
            }

            else if((Keys)e.KeyChar == Keys.S || e.KeyChar == 's')
            {
                if (y <= 6)
                {
                    if (y % 2 == 0 && x == 7)
                    {
                        y++;
                        Console.WriteLine("y = " + y);
                    }
                    else if( y % 2 == 1 && x == 0)
                    {
                        y++;
                        Console.WriteLine("y = " + y);
                    }

               }
                
                rycerz.Location = new Point(x * sizeCard, y * sizeCard);
                
                if (rycerz.Location.X == karty[2, 0].Location.X && rycerz.Location.Y == karty[2, 0].Location.Y)
                {
                    przeciwnik_Radament();
                }

            }

            else if((Keys)e.KeyChar == Keys.A || e.KeyChar == 'a')
            {
                if (y % 2 == 1 && x >= 1)
                {
                    x--;
                    Console.WriteLine("x = " + x);
                }
                
                rycerz.Location = new Point(x * sizeCard, y * sizeCard);

                Console.WriteLine("x = " + rycerz.Location.X);
                Console.WriteLine("y = " + rycerz.Location.Y);

            }

            else if((Keys)e.KeyChar == Keys.W || e.KeyChar == 'w')
            {
                if (x == 1 && x == 6)
                {
                    y--;
                    Console.WriteLine("y = " + y);
                }
                
                rycerz.Location = new Point(x * sizeCard, y * sizeCard);

                Console.WriteLine("x = " + rycerz.Location.X);
                Console.WriteLine("y = " + rycerz.Location.Y);
            }
        }
        
        private void przeciwnik_Beliar()
        {
            
            DialogResult belial_result;
            
            string podpis = "Przeciwnik";
            belial_result = MessageBox.Show("Czy chcesz walczyc z przeciwnikiem Belial " + "\n"
                + "Zycie 1000",podpis,MessageBoxButtons.YesNo);
            if(belial_result == DialogResult.Yes)
            {
                
                p.panel2.BackgroundImage = przeciwnicy_w_grze[0];
                p.panel2.BackgroundImageLayout = ImageLayout.Zoom;

                if (Logowanie.postac == "Czarodziej")
                {
                   
                    p.panel_Postaci.BackgroundImage = global::PuzzleQuest.Properties.Resources.czarodziej;
                    p.panel_Postaci.BackgroundImageLayout = ImageLayout.Zoom;
                }
                else if (Logowanie.postac == "Lucznik")
                {
                    p.panel_Postaci.BackgroundImage = global::PuzzleQuest.Properties.Resources.lucznik;
                    p.panel_Postaci.BackgroundImageLayout = ImageLayout.Zoom;
                }
                else
                {
                    p.panel_Postaci.BackgroundImage = global::PuzzleQuest.Properties.Resources.Paladyn;
                    p.panel_Postaci.BackgroundImageLayout = ImageLayout.Zoom;
                }

                System.Threading.Thread nowagra =
                new System.Threading.Thread(new System.Threading.ThreadStart(otworzInterface));
                //uruchomienie nowego wątku

                
                nowagra.Start();
                
                //zamknięcie starego wątku

                Application.ExitThread();
            }
            else if(belial_result == DialogResult.No)
            {
                x--;
                rycerz.Location = new Point(x * sizeCard, y * sizeCard);
            }
        }
        private void przeciwnik_Radament()
        {

            DialogResult radament_result;

            string podpis = "Przeciwnik";

            radament_result = MessageBox.Show("Czy chcesz walczyc z przeciwnikiem Radament" + "\n"
                + "Zycie 2500", podpis, MessageBoxButtons.YesNo);
            if (radament_result == DialogResult.Yes)
            {

                p.panel2.BackgroundImage = przeciwnicy_w_grze[1];
                p.panel2.BackgroundImageLayout = ImageLayout.Zoom;

                if (Logowanie.postac == "Czarodziej")
                {
                    p.panel_Postaci.BackgroundImage = global::PuzzleQuest.Properties.Resources.czarodziej;
                    p.panel_Postaci.BackgroundImageLayout = ImageLayout.Zoom;
                }
                else if (Logowanie.postac == "Lucznik")
                {
                    p.panel_Postaci.BackgroundImage = global::PuzzleQuest.Properties.Resources.lucznik;
                    p.panel_Postaci.BackgroundImageLayout = ImageLayout.Zoom;
                }
                else
                {
                    p.panel_Postaci.BackgroundImage = global::PuzzleQuest.Properties.Resources.Paladyn;
                    p.panel_Postaci.BackgroundImageLayout = ImageLayout.Zoom;
                }

                System.Threading.Thread nowagra =
                new System.Threading.Thread(new System.Threading.ThreadStart(otworzInterface));
                //uruchomienie nowego wątku


                nowagra.Start();

                //zamknięcie starego wątku

                Application.ExitThread();
            }
            else if (radament_result == DialogResult.No)
            {
                y--;
                rycerz.Location = new Point(x * sizeCard, y * sizeCard);
            }
        }

        //Zapisanie gry
        public void button_zapisz_gre_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Mateusz\Desktop\p\NewPuzzleQuest\PuzzleQuest 14.12.2019\PuzzleQuest\PuzzleQuest\Resources\BazaDanych.mdf; Integrated Security = True; Connect Timeout = 30");
            string dat = "Update Tabela set wspolrzedna_X ='" + x +"', wspolrzedna_Y ='" + y +"' where Login ='" + label_pokaz_login.Text +"'";
            SqlCommand com = new SqlCommand(dat, con);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Zapisano grę.", "Stan gry", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        //zamykanie okna mapy
        private void zamknij_mapa(object sender, FormClosingEventArgs e)
        {
            
            DialogResult wiadomosc1 = MessageBox.Show("Czy na pewno chcesz wyjść z gry?", "Exit", MessageBoxButtons.YesNo);
            if (wiadomosc1 == DialogResult.Yes)
            {
                DialogResult wiadomosc2 = MessageBox.Show("Czy chcesz zapisać grę przed wyjściem?", "Zapis gry", MessageBoxButtons.YesNo);
                if (wiadomosc2 == DialogResult.Yes)
                {
                    // odwolaj sie do przycisku zapisania gry
                    button_zapisz_gre.PerformClick();
                    PuzzleQuest menu_glowne = new PuzzleQuest();
                    menu_glowne.Show();
                }
                else if (wiadomosc2 == DialogResult.No)
                {
                    PuzzleQuest menu_glowne = new PuzzleQuest();
                    menu_glowne.Show(); 
                }
            }
            else if (wiadomosc1 == DialogResult.No)
            {
                e.Cancel = true;
            };
            
        }

    }
}
