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

        //选择文件
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        //开始识别
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("请先选择音频文件！");
                return;
            }
            byte[] data = File.ReadAllBytes(textBox1.Text);
            // 调用语音识别接口
            Asr asrClient = new Asr(string.Empty, API_KEY, SECRET_KEY);
            string content_type = "wvr";
            string dev_pid = "1537";
            var options2 = new Dictionary<string, object>
                {
                    { "普通话", "1537" },
                    { "英语", "1737" },
                    { "粤语", "1637" },
                    { "四川话", "1837" },
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
                if (result["err_no"] != null && result["err_no"].Value<int>() == 0) // 成功返回
                {
                    JArray resultArray = result["result"] as JArray;
                    if (resultArray != null && resultArray.Count > 0)
                    {
                        textBox2.Text = resultArray[0].ToString();
                    }
                    else
                    {
                        MessageBox.Show("未能识别");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误: " + ex.Message);
            }
        }

        //语音合成
        private void createSpeech_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == string.Empty)
            {
                MessageBox.Show("请输入内容！");
                return;
            }
            //校验文本长度
            byte[] bytes = Encoding.UTF8.GetBytes(richTextBox1.Text);
            if (bytes.Length > 1024)
            {
                MessageBox.Show("文本太长，不超过1024字节！");
                return;
            }

            string per = "1";
            string aue = "3";
            Tts ttsClient = new Tts(API_KEY, SECRET_KEY);
            var options2 = new Dictionary<string, object>
                {
                    {"度小宇" , "1"},
                    {"度小美" , "0"},
                    {"度逍遥" , "3"},
                    {"度丫丫" , "4"},
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

                    // 将字节数组写入到文件中
                    File.WriteAllBytes(tempFile, ttsResponse.Data);

                    // 使用mciSendString播放音频文件
                    playAudio(tempFile);
                }
                else
                {
                    // 如果不成功，则显示错误信息
                    string errorMessage = $"错误码: {ttsResponse.ErrorCode}, 错误消息: {ttsResponse.ErrorMsg}";
                    MessageBox.Show($"转音频失败！{errorMessage}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误: " + ex.Message);
            }
        }

        // 播放音频
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
                        // 对于PCM文件，需要指定详细的格式信息
                        int sampleRate;
                        sampleRate = comboBox4.SelectedItem?.ToString() == "pcm-16k" ? 16000 : 8000;
                        int channels = 1; 
                        openPcmFile(filePath, sampleRate, channels);
                        break;
                    default:
                        MessageBox.Show("不支持的文件格式");
                        return;
                }
                mciSendString("play temp_alias", null, 0, IntPtr.Zero);
                // 等待播放结束
                StringBuilder strReturn = new StringBuilder(64);
                do
                {
                    mciSendString("status temp_alias mode", strReturn, 64, IntPtr.Zero);
                } while (!strReturn.ToString().Contains("stopped"));
                // 关闭音频文件
                mciSendString("close temp_alias", null, 0, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                MessageBox.Show("播放音频时发生错误: " + ex.Message);
            }
        }

        private void openMediaFile(string filePath, string mediaType)
        {
            string command = $"open \"{filePath}\" type {mediaType} alias temp_alias";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        private void openPcmFile(string filePath, int sampleRate, int channels)
        {
            int bitsPerSample = 16; // 假设是16位深度
            string command = $"open \"{filePath}\" type WAVEFORMATEX alias temp_alias";
            command += $" format tag pcm samplespersec {sampleRate} channels {channels} bitspersample {bitsPerSample}";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

    }
}
