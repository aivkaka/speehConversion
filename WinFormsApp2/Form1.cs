using Baidu.Aip;
using Baidu.Aip.Speech;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Timers;
using System.Net.Mime;
using Baidu.Aip.Kg;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;



namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private static readonly string API_KEY = "fatdLVhZY6nqYN6Q5bPFIUzJ";
        private static readonly string SECRET_KEY = "1IMsICHNflvfEkuVK0RPvTffo9GmQChG";
        private static readonly string filePath = "D:\\workspace\\cSharp\\file\\";

        [DllImport("winmm.dll", SetLastError = true)]
        static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        public Form1()
        {
            InitializeComponent();

        }

        //ѡ���ļ�
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        //��ʼʶ��
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("����ѡ����Ƶ�ļ���");
                return;
            }
            byte[] data = File.ReadAllBytes(textBox1.Text);
            // ��������ʶ��ӿ�
            Asr asrClient = new Asr(string.Empty, API_KEY, SECRET_KEY);
            string content_type = "wvr";
            string dev_pid = "1537";
            var options2 = new Dictionary<string, object>
                {
                    { "��ͨ��", "1537" },
                    { "Ӣ��", "1737" },
                    { "����", "1637" },
                    { "�Ĵ���", "1837" },
                };
            content_type = comboBox1.SelectedItem?.ToString();
            dev_pid = options2[comboBox2.SelectedItem?.ToString()].ToString();
            var options = new Dictionary<string, object>
                {
                    { "dev_pid", dev_pid },
                };
            
            try
            {
                JObject result = asrClient.Recognize(data, content_type, 16000, options);
                if (result["err_no"] != null && result["err_no"].Value<int>() == 0) // �ɹ�����
                {
                    JArray resultArray = result["result"] as JArray;
                    if (resultArray != null && resultArray.Count > 0)
                    {
                        textBox2.Text = resultArray[0].ToString();
                    }
                    else
                    {
                        MessageBox.Show("δ��ʶ��");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("��������: " + ex.Message);
            }
        }

        //�����ϳ�
        private void createSpeech_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == string.Empty)
            {
                MessageBox.Show("���������ݣ�");
                return;
            }
            //У���ı�����
            byte[] bytes = Encoding.UTF8.GetBytes(richTextBox1.Text);
            if (bytes.Length > 1024)
            {
                MessageBox.Show("�ı�̫����������1024�ֽڣ�");
                return;
            }

            string per = "1";
            string aue = "3";
            Tts ttsClient = new Tts(API_KEY, SECRET_KEY);
            var options2 = new Dictionary<string, object>
                {
                    {"��С��" , "1"},
                    {"��С��" , "0"},
                    {"����ң" , "3"},
                    {"��ѾѾ" , "4"},
                };
            var options3 = new Dictionary<string, object>
                {
                    {"mp3" , "3"},
                    {"pcm-16k" , "4"},
                    {"pcm-8k" , "5"},
                    {"wav" , "6"},
                };
            per = options2[comboBox3.SelectedItem?.ToString()].ToString();
            aue = options3[comboBox4.SelectedItem?.ToString()].ToString();
            string spd = trackBar1.Value.ToString();
            string pit = trackBar2.Value.ToString();
            string vol = trackBar3.Value.ToString();
            var options = new Dictionary<string, object>
                {
                    { "spd", spd },
                    { "pit", pit },
                    { "vol", vol },
                    { "per", per },
                    { "aue", aue }
                };
            try
            {
                TtsResponse ttsResponse = ttsClient.Synthesis(richTextBox1.Text, options);
                if (ttsResponse.Success && ttsResponse.Data != null)
                {
                    string time = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
                    string speech_type = comboBox4.SelectedIndex != -1 ? comboBox4.SelectedItem?.ToString().Substring(0, 3) : "mp3";
                    string tempFile = Path.Combine(filePath, $"{time}.{speech_type}");

                    // ���ֽ�����д�뵽�ļ���
                    File.WriteAllBytes(tempFile, ttsResponse.Data);

                    // ʹ��mciSendString������Ƶ�ļ�
                    playAudio(tempFile);
                }
                else
                {
                    // ������ɹ�������ʾ������Ϣ
                    string errorMessage = $"������: {ttsResponse.ErrorCode}, ������Ϣ: {ttsResponse.ErrorMsg}";
                    MessageBox.Show($"ת��Ƶʧ�ܣ�{errorMessage}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("��������: " + ex.Message);
            }
        }

        // ������Ƶ
        private void playAudio(string filePath)
        {
            try
            {
                string extension = System.IO.Path.GetExtension(filePath).ToLower();
                switch (extension)
                {
                    case ".mp3":
                        openMediaFile(filePath, "mp3");
                        break;
                    case ".wav":
                        openMediaFile(filePath, "waveaudio");
                        break;
                    case ".pcm":
                        // ����PCM�ļ�����Ҫָ����ϸ�ĸ�ʽ��Ϣ
                        int sampleRate;
                        sampleRate = comboBox4.SelectedItem?.ToString() == "pcm-16k" ? 16000 : 8000;
                        int channels = 1; 
                        openPcmFile(filePath, sampleRate, channels);
                        break;
                    default:
                        MessageBox.Show("��֧�ֵ��ļ���ʽ");
                        return;
                }
                mciSendString("play temp_alias", null, 0, IntPtr.Zero);
                // �ȴ����Ž���
                StringBuilder strReturn = new StringBuilder(64);
                do
                {
                    mciSendString("status temp_alias mode", strReturn, 64, IntPtr.Zero);
                } while (!strReturn.ToString().Contains("stopped"));
                // �ر���Ƶ�ļ�
                mciSendString("close temp_alias", null, 0, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                MessageBox.Show("������Ƶʱ��������: " + ex.Message);
            }
        }

        private void openMediaFile(string filePath, string mediaType)
        {
            string command = $"open \"{filePath}\" type {mediaType} alias temp_alias";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        private void openPcmFile(string filePath, int sampleRate, int channels)
        {
            int bitsPerSample = 16; // ������16λ���
            string command = $"open \"{filePath}\" type WAVEFORMATEX alias temp_alias";
            command += $" format tag pcm samplespersec {sampleRate} channels {channels} bitspersample {bitsPerSample}";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

    }
}
