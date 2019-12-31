using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using System.Media;
using System.Diagnostics;
using System.IO;



namespace SpeechRecognition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private

        static Label l;

        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.7) l.Text = e.Result.Text;
        }	
        
        private void Form1_Shown(object sender, EventArgs e)
        {
            l = label1;
            
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-ru");
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice();
          
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);


           

            Choices numbers = new Choices();
            numbers.Add(new string[] { "доброе утро джарвис","гугл",
                "я вернулся","погода","визжуал студио","ворд"  , "пока", "вконтакте","калькулятор" 
                ,"настройки","ютуб","открой закладки","расписание","рэд студио"});// поменять 
            // слова

   
            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = ci;
            gb.Append(numbers);


            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);

            sre.RecognizeAsync(RecognizeMode.Multiple);
            sre.SpeechRecognized += ree;
        }

        private void ree(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)

            {
                case "доброе утро джарвис":
                    SoundPlayer sndPlayer = new SoundPlayer(@"D:\программы по программированию\jarvis\Jarvis Sound Pack\Доброе утро.wav");
                    sndPlayer.Play();
                    break;
                case "гугл":
                    SoundPlayer sndPlayer1 = new SoundPlayer(@"D:\программы по программированию\jarvis\Jarvis Sound Pack\Да сэр.wav");
                    sndPlayer1.Play();
                    Process.Start("chrome.exe");
                    break;

                case "визжуал студио":
                    SoundPlayer sndPlayer2 = new SoundPlayer(@"D:\программы по программированию\jarvis\Jarvis Sound Pack\Как пожелаете .wav");
                    sndPlayer2.Play();
                    Process.Start(@"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.exe");
                    break;
                case "я вернулся":
                    SoundPlayer sndPlayer3 = new SoundPlayer(@"D:\программы по программированию\jarvis\Jarvis Sound Pack\Джарвис - приветствие.wav");
                    sndPlayer3.Play();
                    break;
               case "ворд":
                    SoundPlayer sndPlayer5 = new SoundPlayer(@"D:\программы по программированию\jarvis\Jarvis Sound Pack\Есть.wav");
                    sndPlayer5.Play();
                    Process.Start(@"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE");
                    break;

                case "погода":
                    SoundPlayer sndPlayer4 = new SoundPlayer(@"D:\программы по программированию\jarvis\Jarvis Sound Pack\Да сэр.wav");
                    sndPlayer4.Play();
                    Process.Start("http://yandex.ru/pogoda/balashiha");
                    break;
                case "вконтакте":
                    SoundPlayer sndPlayer6 = new SoundPlayer(@"D:\программы по программированию\jarvis\Jarvis Sound Pack\Да сэр.wav");
                    sndPlayer6.Play();
                    Process.Start("http://vk.com");
                    break;
                case "калькулятор":
                    SoundPlayer sndPlayer7 = new SoundPlayer(@"D:\программы по программированию\jarvis\Jarvis Sound Pack\Есть.wav");
                    sndPlayer7.Play();
                    Process.Start("calc.exe");
                    break;

                 


                case "открой закладки":
                    SoundPlayer sndPlayer10 = new SoundPlayer(@"D:\программы по программированию\jarvis\Jarvis Sound Pack\Есть.wav");
                    sndPlayer10.Play();
                    Process.Start("chrome://bookmarks/");
                    break;

                case "ютуб":
                    SoundPlayer sndPlayer9 = new SoundPlayer(@"D:\программы по программированию\jarvis\Jarvis Sound Pack\Да сэр.wav");
                    sndPlayer9.Play();
                    Process.Start("https://www.youtube.com/");
                    break;
                case "настройки":
                    Process.Start(@"D:\программы по программированию\jarvis\SpeechRecognition.sln");
                  

                    break;

                case "расписание":
                    SoundPlayer sndPlayer11 = new SoundPlayer(@"D:\программы по программированию\jarvis\Jarvis Sound Pack\Да сэр.wav");
                    sndPlayer11.Play();
                    Process.Start(@"D:\задания для института\425.xlsx");
                    break;

                case "пока":
                    Application.Exit();
                    break;

                case "рэд студио":
                    SoundPlayer sndPlayer12 = new SoundPlayer(@"D:\программы по программированию\jarvis\Jarvis Sound Pack\Да сэр.wav");
                    sndPlayer12.Play();
                    Process.Start(@"C:\Program Files (x86)\Embarcadero\Studio\19.0\bin\bds.exe");
                    break;

            }
            
        }
    }
}
