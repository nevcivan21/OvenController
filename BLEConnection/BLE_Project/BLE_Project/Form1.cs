using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Storage.Streams;

namespace BLE_Project
{
    public partial class Form1 : Form
    {
        private BluetoothLEDevice bluetoothLEDevice = null;

        private GattDeviceServicesResult result { get; set; }

        private DeviceWatcher deviceWatcher = null;

        private DeviceInformation device = null;

        private GattCharacteristic selectedCharacteristic = null;

        private GattDeviceService selectedService = null;

        private string HEART_RATE_SERVICE_ID = "c201";  //burdaki olan değişim gösterebilir olan cihazla uudlere bak


        #region Tanımlamalar
        int menüMod = 0;
        int oldMenüMod = 0;
        int tabPage_Flag = 0;
        string string_buffer_circle = "";
        int Data_Buffer = 0;
        Thread th1;

        private bool Timer_buffer = false;

        //****************************************Gelen veri değişkenleri***************************************
        string SendData_Buffer = "";
        int int_SendData_Buffer = 0;
        int old_int_SendData_Buffer = 0;
        int Gelen_Saat = 0;
        int Gelen_Dk = 0;
        int Gelen_SleepState;
        int Gelen_SıcaklıkDegeri = 0;
        int Gelen_TimerFirstButtonSaat = 0;
        int Gelen_TimerFirstButtonDk = 0;
        int Gelen_TimerSecondButtonSaat = 0;
        int Gelen_TimerSecondButtonDk = 0;
        int Gelen_TimerThirdButtonSaat = 0;
        int Gelen_TimerThirdButtonDk = 0;
        int Gelen_SettingsEcoState;
        int Gelen_SettingsClockSaat = 0;
        int Gelen_SettingsClockDk = 0;
        int Gelen_SettingsBuzzer = 0; // Değişebilir buna bak
        int Gelen_SettingsParlaklık = 0;
        int Gelen_SettingsBluetooth = 0;
        int Gelen_SettingsLanguage = 0;
        bool Language_Flag = false;
        int Gelen_SettingsNightMode = 0;
        int Gelen_SettingsSleepTime = 0;
        int Gelen_SettingsTempUnit = 0;
        int Gelen_ProgramMode = 0;
        int Gelen_HaziryemekSıcaklık = 0;
        int Gelen_HaziryemekSaat = 0;
        int Gelen_HaziryemekDk = 0;
        int Temp_unit_flag = 0;
        bool Circle_Angle_Veri_Flag = false;
        //********************************************************************************************


        //************************************Gelen OldVeriler****************************************

        /*int old_Gelen_TimerFirstButtonSaat = 50;
        int old_Gelen_TimerFirstButtonDk = 50;
        int old_Gelen_TimerSecondButtonSaat = 50;
        int old_Gelen_TimerSecondButtonDk = 50;
        int old_Gelen_TimerThirdButtonSaat = 50;
        int old_Gelen_TimerThirdButtonDk = 50;
        int old_Gelen_SettingsEcoState = 50;
        int old_Gelen_SettingsClockSaat = 50;
        int old_Gelen_SettingsClockDk = 50;
        int old_Gelen_SettingsBuzzer = 50; // Değişebilir buna bak
        int old_Gelen_SettingsParlaklık = 50;
        int old_Gelen_SettingsBluetooth =50;
        int old_Gelen_SettingsLanguage = 50;
        int old_Gelen_SettingsNightMode = 50;
        int old_Gelen_SettingsSleepTime = 50;
        int old_Gelen_SettingsTempUnit = 50;*/

        int old_Gelen_HaziryemekSıcaklık = 50;
        int old_Gelen_HaziryemekSaat = 50;
        int old_Gelen_HaziryemekDk = 50;

        //**********************************************************Circle Angle Sliderları yollama***********************************
        int Circle_Angle_Picker_Buffer = 0;             //Temperature için.
        string String_Circle_Angle_Buffer = "";



        string String_Circle_Buffer_Settings = "";
        private bool Circle_Angle_Veri_Flag_Settings = false;
        int int_Circle_SendData_Buffer_Settings = 0;
        int old_int_Circle_SendData_Buffer_Settings = 0;

        int CircleAnglePickerBufferVeri = 0;


        string String_Circle_Buffer_Timer = "";
        bool Circle_Angle_Veri_Flag_Timer = false;
        int int_Circle_SendData_Buffer_Timer = 0;
        int old_int_Circle_SendData_Buffer_Timer = 0;


        string String_Circle_Buffer_Meat = "";
        bool Circle_Angle_Veri_Flag_Meat = false;
        int int_Circle_SendData_Buffer_Meat = 0;
        int old_int_Circle_SendData_Buffer_Meat = 0;

        string String_Circle_Buffer_Chicken = "";
        bool Circle_Angle_Veri_Flag_Chicken = false;
        int int_Circle_SendData_Buffer_Chicken = 0;
        int old_int_Circle_SendData_Buffer_Chicken = 0;

        string String_Circle_Buffer_Fish = "";
        bool Circle_Angle_Veri_Flag_Fish = false;
        int int_Circle_SendData_Buffer_Fish = 0;
        int old_int_Circle_SendData_Buffer_Fish = 0;

        string String_Circle_Buffer_Vegan = "";
        bool Circle_Angle_Veri_Flag_Vegan = false;
        int int_Circle_SendData_Buffer_Vegan = 0;
        int old_int_Circle_SendData_Buffer_Vegan = 0;

        string String_Circle_Buffer_Paste = "";
        bool Circle_Angle_Veri_Flag_Paste = false;
        int int_Circle_SendData_Buffer_Paste = 0;
        int old_int_Circle_SendData_Buffer_Paste = 0;

        string String_Circle_Buffer_Pizza = "";
        bool Circle_Angle_Veri_Flag_Pizza = false;
        int int_Circle_SendData_Buffer_Pizza = 0;
        int old_int_Circle_SendData_Buffer_Pizza = 0;

        string String_Circle_Buffer_Cake = "";
        bool Circle_Angle_Veri_Flag_Cake = false;
        int int_Circle_SendData_Buffer_Cake = 0;
        int old_int_Circle_SendData_Buffer_Cake = 0;

        string String_Circle_Buffer_Cookie = "";
        bool Circle_Angle_Veri_Flag_Cookie = false;
        int int_Circle_SendData_Buffer_Cookie = 0;
        int old_int_Circle_SendData_Buffer_Cookie = 0;

        string String_Circle_Buffer_Pie = "";
        bool Circle_Angle_Veri_Flag_Pie = false;
        int int_Circle_SendData_Buffer_Pie = 0;
        int old_int_Circle_SendData_Buffer_Pie = 0;

        string String_Circle_Buffer_Bread = "";
        bool Circle_Angle_Veri_Flag_Bread = false;
        int int_Circle_SendData_Buffer_Bread = 0;
        int old_int_Circle_SendData_Buffer_Bread = 0;

        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            tabControl1.SelectedIndex = 1;
            BLE_Connection();
            timerVeri.Start();
            th1 = new Thread(Sayfa_veriler);
            th1.Start();
          
        }

        #region Status
        private void lblStatusFuncConnecting()
        {
            lbl_StatusTemp.ForeColor = Color.Yellow;
            lbl_StatusTemp.Text = "Connecting...";

            btnTemp_ileri.Enabled = false;

            btn_temp_Ana.Enabled = false;
        }

        private void lblStatusConnected()
        {
            lbl_StatusTemp.ForeColor = Color.Green;
            lbl_StatusTemp.Text = "Connected";

            btnTemp_ileri.Enabled = true;
            btn_temp_Ana.Enabled = true;
            lbl_StatusTmr1.ForeColor = Color.Green;
            lbl_StatusTmr1.Text = "Connected";

            lbl_StatusTmr2.ForeColor = Color.Green;
            lbl_StatusTmr2.Text = "Connected";

            lbl_StatusSettings1.ForeColor = Color.Green;
            lbl_StatusSettings1.Text = "Connected";

            lbl_StatusSettings2.ForeColor = Color.Green;
            lbl_StatusSettings2.Text = "Connected";

            lbl_StatusFav.ForeColor = Color.Green;
            lbl_StatusFav.Text = "Connected";

            lbl_StatusMeat.ForeColor = Color.Green;
            lbl_StatusMeat.Text = "Connected";

            lbl_StatusChicken.ForeColor = Color.Green;
            lbl_StatusChicken.Text = "Connected";

            lbl_StatusFish.ForeColor = Color.Green;
            lbl_StatusFish.Text = "Connected";

            lbl_StatusVegan.ForeColor = Color.Green;
            lbl_StatusVegan.Text = "Connected";

            lbl_StatusPaste.ForeColor = Color.Green;
            lbl_StatusPaste.Text = "Connected";

            lbl_StatusPizza.ForeColor = Color.Green;
            lbl_StatusPizza.Text = "Connected";

            lbl_StatusCake.ForeColor = Color.Green;
            lbl_StatusCake.Text = "Connected";

            lbl_StatusCookie.ForeColor = Color.Green;
            lbl_StatusCookie.Text = "Connected";

            lbl_StatusPie.ForeColor = Color.Green;
            lbl_StatusPie.Text = "Connected";

            lbl_StatusBread.ForeColor = Color.Green;
            lbl_StatusBread.Text = "Connected";
        }

        #endregion

        #region Bağlantı Alanı
        private async void BLE_Connection()
        {
                lblStatusFuncConnecting();
                
                string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected" };

                deviceWatcher = DeviceInformation.CreateWatcher(
                                    BluetoothLEDevice.GetDeviceSelectorFromPairingState(false),
                                    requestedProperties,
                                    DeviceInformationKind.AssociationEndpoint);

                deviceWatcher.Added += DeviceWatcher_Added;                                                                              //butona bir kere tıkladığımızda buradaki fonksiyona dallanıyor ve orada bizim cihazımızın args yardımı ile bilgilerini alıyoruz.
                deviceWatcher.Updated += DeviceWatcher_Updated;
                deviceWatcher.Removed += DeviceWatcher_Removed;

                deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
                deviceWatcher.Stopped += DeviceWatcher_Stopped;

                // Start the watcher.

                deviceWatcher.Start();

                while (true)
                {
                    if (device == null)
                    {
                        Thread.Sleep(200);
                    }
                    else
                    {
                        bluetoothLEDevice = await BluetoothLEDevice.FromIdAsync(device.Id);
                        result = await bluetoothLEDevice.GetGattServicesAsync();

                        if (result.Status == GattCommunicationStatus.Success)
                        {
                            var services = result.Services;
                            foreach (var service in services)
                            {
                                if (service.Uuid.ToString("N").Substring(4, 4) == HEART_RATE_SERVICE_ID)
                                {
                                    GattCharacteristicsResult characteristicsResult = await service.GetCharacteristicsAsync();

                                    if (characteristicsResult.Status == GattCommunicationStatus.Success)
                                    {
                                        var characteristics = characteristicsResult.Characteristics;
                                        foreach (var characteristic in characteristics)
                                        {
                                            GattCharacteristicProperties properties = characteristic.CharacteristicProperties;

                                            if (properties.HasFlag(GattCharacteristicProperties.Read))  
                                            {

                                                GattCommunicationStatus status = await characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);

                                                if (status == GattCommunicationStatus.Success)
                                                {
                                                    characteristic.ValueChanged += Characteristic_ValueChanged;
                                                    selectedCharacteristic = characteristic;
                                                    selectedService = service;
                                                    lblStatusConnected();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
        }
        private void DeviceWatcher_Stopped(DeviceWatcher sender, object args)
        {

        }

        private void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object args)
        {

        }

        private void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate args)
        {

        }

        private void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate args)
        {

        }

        private void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation args)
        {
            if (args.Name == "OvenCont")            
            {
                device = args;
            }
        }
        
        public async void BLE_Disconnect()
        {
            if (BLE_IsConnected())          //Eğer bağlantı açık ise
            {
                selectedCharacteristic.ValueChanged -= Characteristic_ValueChanged;         //Valueyi -= yapıp bir azaltıp kapat.
                bluetoothLEDevice.Dispose();        //Ble deviceyi dispose et.
                bluetoothLEDevice = null;

                selectedService.Dispose();      //servis bilgisini selectedServiceye aktardık ve onu da dispose ettik.
                selectedService = null;

                var b = Task.Delay(500);
                await b;  //dispose ederken küçük bir bekleme payı olması gerekiyor.
                
                
            }
        }

        public bool BLE_IsConnected()    //eğer BLE null değilse ve bağlantı açık ise true döndür.
        {
            if (bluetoothLEDevice != null && bluetoothLEDevice.ConnectionStatus == BluetoothConnectionStatus.Connected)
            {
                return true;
            }
            else
                return false;
        }

        #endregion

        #region Veri Okuma
        private void Characteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            DataReader reader = DataReader.FromBuffer(args.CharacteristicValue);

            byte[] byteArray = new byte[reader.UnconsumedBufferLength];  // UnconsumedBufferLength kadar byte bir veri gönderdiğimiz için boyutunu 10 byte.

            reader.ReadBytes(byteArray);

            var str = Encoding.ASCII.GetString(byteArray);
            string[] strdatabuffer = str.Split('/');
            string Header = strdatabuffer[0];
            if (Header == "1")         //İlk değerden kontrol sağlıyoruz.Son değeride ekleyebiliriz istersek.
            {
                menüMod =Convert.ToInt16(strdatabuffer[1]);
                Gelen_ProgramMode =Convert.ToInt16(strdatabuffer[2]);
                Gelen_Saat =Convert.ToInt16(strdatabuffer[5]);
                Gelen_Dk =Convert.ToInt16(strdatabuffer[6]);
                Gelen_SleepState = Convert.ToInt16(strdatabuffer[8]);
                Gelen_SıcaklıkDegeri = Convert.ToInt16(strdatabuffer[9]);
                Gelen_TimerFirstButtonSaat = Convert.ToInt16(strdatabuffer[10]);
                Gelen_TimerFirstButtonDk = Convert.ToInt16(strdatabuffer[11]);
                Gelen_TimerSecondButtonSaat = Convert.ToInt16(strdatabuffer[12]);
                Gelen_TimerSecondButtonDk = Convert.ToInt16(strdatabuffer[13]);
                Gelen_TimerThirdButtonSaat = Convert.ToInt16(strdatabuffer[14]);
                Gelen_TimerThirdButtonDk = Convert.ToInt16(strdatabuffer[15]);
                Gelen_SettingsEcoState = Convert.ToInt16(strdatabuffer[16]);
                Gelen_SettingsClockSaat = Convert.ToInt16(strdatabuffer[17]);
                Gelen_SettingsClockDk = Convert.ToInt16(strdatabuffer[18]);
                Gelen_SettingsBuzzer = Convert.ToInt16(strdatabuffer[19]);
                Gelen_SettingsParlaklık = Convert.ToInt16(strdatabuffer[20]);
                Gelen_SettingsBluetooth = Convert.ToInt16(strdatabuffer[21]);
                Gelen_SettingsLanguage = Convert.ToInt16(strdatabuffer[22]);
                Gelen_SettingsNightMode = Convert.ToInt16(strdatabuffer[23]);
                Gelen_SettingsSleepTime = Convert.ToInt16(strdatabuffer[24]);
                Gelen_SettingsTempUnit = Convert.ToInt16(strdatabuffer[25]);
                Gelen_HaziryemekSıcaklık = Convert.ToInt16(strdatabuffer[26]);
                Gelen_HaziryemekSaat = Convert.ToInt16(strdatabuffer[27]);
                Gelen_HaziryemekDk = Convert.ToInt16(strdatabuffer[28]);
            }
                Data_Buffer = Gelen_SıcaklıkDegeri;         //Sıcaklığı Slider'de göstermek için.
                
                if (Temp_unit_flag == 0)                    
                {
                    lblGelenTemp.Text = Gelen_SıcaklıkDegeri.ToString() + "°C";
                }
                if (Temp_unit_flag == 1)
                {
                    lblGelenTemp.Text = Gelen_SıcaklıkDegeri.ToString() + "°C"; //Gelen veriye göre derece veya Fahreneit olacağı.
                }
                if (Temp_unit_flag == 2)
                {
                    lblGelenTemp.Text = Gelen_SıcaklıkDegeri.ToString() + "°F";
                }


                if (Circle_Angle_Veri_Flag == false)        //Gelen veri mouseyi bıraktığımızda çizdirsin.
                {
                    gelenTemp_Function();
                }

                lblTemperatureÜst_Saat.Text = Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblTimer1Üst_Saat.Text =      Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblTimer2Üst_Saat.Text =      Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblSettings1Üst_Saat.Text =   Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblSetting2Üst_Saat.Text =    Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblFavorites1Üst_Saat.Text =  Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblFavMeatÜst_Saat.Text =     Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblFavChickenÜst_Saat.Text =  Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblFavFishÜst_Saat.Text =     Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblFavVeganÜst_Saat.Text =    Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblFavPasteÜst_Saat.Text =    Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblFavPizzaÜst_Saat.Text =    Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblFavCakeÜst_Saat.Text =     Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblFavCookieÜst_Saat.Text =   Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblFavPieÜst_Saat.Text =      Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();
                lblFavBreadÜst_Saat.Text =    Gelen_Saat.ToString() + ":" + Gelen_Dk.ToString();



                if (Gelen_SleepState == 1)              //Eğer veri 1 ise uyku modu
                {
                    tabControl1.SelectedIndex = 0;      //Sleep Sayfasına git
                }
                if (Gelen_SleepState == 0)              //Eğer veri 0 ise uyan
                {
                    tabControl1.SelectedIndex = tabPage_Flag;       //En son hangi sayfadaysa oraya dön.
                }
        }

        #region Menü Mod
        private void timerVeri_Tick_1(object sender, EventArgs e)
        {
            Sayfa_veriler();                //Gelen veriler burada kontrol edilip işleme alınıyor.
        }
        public async void Sayfa_veriler()
        {
            if (Timer_buffer)                   //Butondan veri gönderdiğimizde ilk buraya girip bir delay oluşturuyor.
            {
                var a = Task.Delay(300);               //Delay fonksiyonu.
                await a;
                Timer_buffer = false;
            }
            else
            {
                if (menüMod != oldMenüMod)
                {
                    if (menüMod == 1)       //Sıcaklık ekranı
                    {
                        tabPage_Flag = 1;
                        tabControl1.SelectedIndex = 1;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 2)       //Timer Ekranı
                    {
                        tabPage_Flag = 2;
                        tabControl1.SelectedIndex = 2;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 3)       //Settings Sayfası
                    {
                        tabPage_Flag = 4;
                        tabControl1.SelectedIndex = 4;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 4)       //Favori sayfası
                    {
                        tabPage_Flag = 6;
                        tabControl1.SelectedIndex = 6;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 5)       //Timer ikinci sayfa H.A.Cooking buton işlemleri
                    {
                        tabPage_Flag = 3;
                        tabControl1.SelectedIndex = 3;
                        btn_tmr_ha.ForeColor = Color.Red;
                        btnTimer2_Acook.ForeColor = Color.White;
                        btn_tmr_Alarm.ForeColor = Color.White;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 6)       //Timer ikinci sayfa A.Cooking buton işlemleri
                    {
                        tabPage_Flag = 3;
                        tabControl1.SelectedIndex = 3;
                        btn_tmr_ha.ForeColor = Color.White;
                        btnTimer2_Acook.ForeColor = Color.Red;
                        btn_tmr_Alarm.ForeColor = Color.White;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 7)       //Timer ikinci sayfa Alarm Buton işlemleri
                    {
                        tabPage_Flag = 3;
                        tabControl1.SelectedIndex = 3;
                        btn_tmr_ha.ForeColor = Color.White;
                        btnTimer2_Acook.ForeColor = Color.White;
                        btn_tmr_Alarm.ForeColor = Color.Red;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 8)       //Settings ikinci sayfa Economic Buton işlemleri
                    {

                        tabControl1.SelectedIndex = 5;
                        tabPage_Flag = 5;
                        btnSettings_Night.ForeColor = Color.White;
                        btnSettings_SleepTime.ForeColor = Color.White;
                        btnSettings_Temp.ForeColor = Color.White;
                        btnSettings_Bright.ForeColor = Color.White;
                        btnSettings_Bluetooth.ForeColor = Color.White;
                        btnSettings_Language.ForeColor = Color.White;
                        btnSettings_Economic.ForeColor = Color.Red;
                        btnSettings_Clock.ForeColor = Color.White;
                        btnSettings_Sound.ForeColor = Color.White;


                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 9)       //Settings ikinci sayfa Clock Buton işlemleri
                    {

                        tabControl1.SelectedIndex = 5;
                        tabPage_Flag = 5;
                        btnSettings_Night.ForeColor = Color.White;
                        btnSettings_SleepTime.ForeColor = Color.White;
                        btnSettings_Temp.ForeColor = Color.White;
                        btnSettings_Bright.ForeColor = Color.White;
                        btnSettings_Bluetooth.ForeColor = Color.White;
                        btnSettings_Language.ForeColor = Color.White;
                        btnSettings_Economic.ForeColor = Color.White;
                        btnSettings_Clock.ForeColor = Color.Red;
                        btnSettings_Sound.ForeColor = Color.White;

                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 10)       //Settings ikinci sayfa Sound Buton işlemleri
                    {
                        tabPage_Flag = 5;
                        tabControl1.SelectedIndex = 5;
                        btnSettings_Night.ForeColor = Color.White;
                        btnSettings_SleepTime.ForeColor = Color.White;
                        btnSettings_Temp.ForeColor = Color.White;
                        btnSettings_Bright.ForeColor = Color.White;
                        btnSettings_Bluetooth.ForeColor = Color.White;
                        btnSettings_Language.ForeColor = Color.White;
                        btnSettings_Economic.ForeColor = Color.White;
                        btnSettings_Clock.ForeColor = Color.White;
                        btnSettings_Sound.ForeColor = Color.Red;

                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 11)       //Settings ikinci sayfa Brightness Buton işlemleri
                    {
                        tabPage_Flag = 5;
                        tabControl1.SelectedIndex = 5;
                        btnSettings_Night.ForeColor = Color.White;
                        btnSettings_SleepTime.ForeColor = Color.White;
                        btnSettings_Temp.ForeColor = Color.White;
                        btnSettings_Bright.ForeColor = Color.Red;
                        btnSettings_Bluetooth.ForeColor = Color.White;
                        btnSettings_Language.ForeColor = Color.White;
                        btnSettings_Economic.ForeColor = Color.White;
                        btnSettings_Clock.ForeColor = Color.White;
                        btnSettings_Sound.ForeColor = Color.White;

                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 12)       //Settings ikinci sayfa Bluetooth Buton işlemleri
                    {
                        tabPage_Flag = 5;
                        tabControl1.SelectedIndex = 5;
                        btnSettings_Night.ForeColor = Color.White;
                        btnSettings_SleepTime.ForeColor = Color.White;
                        btnSettings_Temp.ForeColor = Color.White;
                        btnSettings_Bright.ForeColor = Color.White;
                        btnSettings_Bluetooth.ForeColor = Color.Red;
                        btnSettings_Language.ForeColor = Color.White;
                        btnSettings_Economic.ForeColor = Color.White;
                        btnSettings_Clock.ForeColor = Color.White;
                        btnSettings_Sound.ForeColor = Color.White;


                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 13)       //Settings ikinci sayfa Language Buton işlemleri
                    {
                        tabPage_Flag = 5;
                        tabControl1.SelectedIndex = 5;
                        btnSettings_Night.ForeColor = Color.White;
                        btnSettings_SleepTime.ForeColor = Color.White;
                        btnSettings_Temp.ForeColor = Color.White;
                        btnSettings_Bright.ForeColor = Color.White;
                        btnSettings_Bluetooth.ForeColor = Color.White;
                        btnSettings_Language.ForeColor = Color.Red;
                        btnSettings_Economic.ForeColor = Color.White;
                        btnSettings_Clock.ForeColor = Color.White;
                        btnSettings_Sound.ForeColor = Color.White;



                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 14)       //Settings ikinci sayfa Night Mode Buton işlemleri
                    {
                        tabPage_Flag = 5;
                        tabControl1.SelectedIndex = 5;
                        btnSettings_Night.ForeColor = Color.Red;
                        btnSettings_SleepTime.ForeColor = Color.White;
                        btnSettings_Temp.ForeColor = Color.White;
                        btnSettings_Bright.ForeColor = Color.White;
                        btnSettings_Bluetooth.ForeColor = Color.White;
                        btnSettings_Language.ForeColor = Color.White;
                        btnSettings_Economic.ForeColor = Color.White;
                        btnSettings_Clock.ForeColor = Color.White;
                        btnSettings_Sound.ForeColor = Color.White;

                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 15)       //Settings ikinci sayfa SleepTime Buton işlemleri
                    {
                        tabPage_Flag = 5;
                        tabControl1.SelectedIndex = 5;
                        btnSettings_Night.ForeColor = Color.White;
                        btnSettings_SleepTime.ForeColor = Color.Red;
                        btnSettings_Temp.ForeColor = Color.White;
                        btnSettings_Bright.ForeColor = Color.White;
                        btnSettings_Bluetooth.ForeColor = Color.White;
                        btnSettings_Language.ForeColor = Color.White;
                        btnSettings_Economic.ForeColor = Color.White;
                        btnSettings_Clock.ForeColor = Color.White;
                        btnSettings_Sound.ForeColor = Color.White;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 16)       //Settings ikinci sayfa Temp Unit Buton işlemleri
                    {
                        tabPage_Flag = 5;
                        tabControl1.SelectedIndex = 5;
                        btnSettings_Night.ForeColor = Color.White;
                        btnSettings_SleepTime.ForeColor = Color.White;
                        btnSettings_Temp.ForeColor = Color.Red;
                        btnSettings_Bright.ForeColor = Color.White;
                        btnSettings_Bluetooth.ForeColor = Color.White;
                        btnSettings_Language.ForeColor = Color.White;
                        btnSettings_Economic.ForeColor = Color.White;
                        btnSettings_Clock.ForeColor = Color.White;
                        btnSettings_Sound.ForeColor = Color.White;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 17)       //Favoriler Meat Sayfası
                    {
                        tabPage_Flag = 7;
                        tabControl1.SelectedIndex = 7;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 18)       //Favoriler Chicken Sayfası
                    {
                        tabPage_Flag = 8;
                        tabControl1.SelectedIndex = 8;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 19)       //Favoriler Fish Sayfası
                    {
                        tabPage_Flag = 9;
                        tabControl1.SelectedIndex = 9;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 20)       //Favoriler Vegetable Sayfası
                    {
                        tabPage_Flag = 10;
                        tabControl1.SelectedIndex = 10;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 21)       //Favoriler Paste Sayfası
                    {
                        tabPage_Flag = 11;
                        tabControl1.SelectedIndex = 11;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 22)       //Favoriler Pizza Sayfası
                    {
                        tabPage_Flag = 12;
                        tabControl1.SelectedIndex = 12;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 23)       //Favoriler Cake Sayfası
                    {
                        tabPage_Flag = 13;
                        tabControl1.SelectedIndex = 13;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 24)       //Favoriler Cookie Sayfası
                    {
                        tabPage_Flag = 14;
                        tabControl1.SelectedIndex = 14;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 25)       //Favoriler Pie Sayfası
                    {
                        tabPage_Flag = 15;
                        tabControl1.SelectedIndex = 15;
                        oldMenüMod = menüMod;
                    }
                    if (menüMod == 26)       //Favoriler Bread Sayfası
                    {
                        tabPage_Flag = 16;
                        tabControl1.SelectedIndex = 16;
                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 27)       //Favoriler Meat Sayfası(Derece)
                    {
                        tabPage_Flag = 7;
                        tabControl1.SelectedIndex = 7;
                        lblmeatDerece.ForeColor = Color.Red;
                        lblmeatdakika.ForeColor = Color.White;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 28)       //Favoriler Meat Sayfası(Dakika)
                    {
                        tabPage_Flag = 7;
                        tabControl1.SelectedIndex = 7;
                        lblmeatDerece.ForeColor = Color.White;
                        lblmeatdakika.ForeColor = Color.Red;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 29)       //Favoriler Chicken Sayfası(Derece)
                    {
                        tabPage_Flag = 8;
                        tabControl1.SelectedIndex = 8;
                        lblchickenDerece.ForeColor = Color.Red;
                        lblchickendakika.ForeColor = Color.White;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 30)       //Favoriler Chicken Sayfası(Dakika)
                    {
                        tabPage_Flag = 8;
                        tabControl1.SelectedIndex = 8;
                        lblchickenDerece.ForeColor = Color.White;
                        lblchickendakika.ForeColor = Color.Red;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 31)       //Favoriler Fish Sayfası(Derece)
                    {
                        tabPage_Flag = 9;
                        tabControl1.SelectedIndex = 9;
                        lblFishderece.ForeColor = Color.Red;
                        lblFishSaat.ForeColor = Color.White;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 32)       //Favoriler Fish Sayfası(Dakika)
                    {
                        tabPage_Flag = 9;
                        tabControl1.SelectedIndex = 9;
                        lblFishderece.ForeColor = Color.White;
                        lblFishSaat.ForeColor = Color.Red;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 33)       //Favoriler Vegatables Sayfası(Derece)
                    {
                        tabPage_Flag = 10;
                        tabControl1.SelectedIndex = 10;
                        lblVeganDerece.ForeColor = Color.Red;
                        lblVeganSaat.ForeColor = Color.White;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 34)       //Favoriler Vegatables Sayfası(Dakika)
                    {
                        tabPage_Flag = 10;
                        tabControl1.SelectedIndex = 10;
                        lblVeganDerece.ForeColor = Color.White;
                        lblVeganSaat.ForeColor = Color.Red;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 35)       //Favoriler Paste Sayfası(Derece)
                    {
                        tabPage_Flag = 11;
                        tabControl1.SelectedIndex = 11;
                        lblPasteDerece.ForeColor = Color.Red;
                        lblPasteSaat.ForeColor = Color.White;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 36)       //Favoriler Paste Sayfası(Dakika)
                    {
                        tabPage_Flag = 11;
                        tabControl1.SelectedIndex = 11;
                        lblPasteDerece.ForeColor = Color.White;
                        lblPasteSaat.ForeColor = Color.Red;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 37)       //Favoriler Pizza Sayfası(Derece)
                    {

                        tabPage_Flag = 12;
                        tabControl1.SelectedIndex = 12;
                        lblPizzaDerece.ForeColor = Color.Red;
                        lblPizzaSaat.ForeColor = Color.White;


                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 38)       //Favoriler Pizza Sayfası(Dakika)
                    {
                        tabPage_Flag = 12;
                        tabControl1.SelectedIndex = 12;
                        lblPizzaDerece.ForeColor = Color.White;
                        lblPizzaSaat.ForeColor = Color.Red;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 39)       //Favoriler Cake Sayfası(Derece)
                    {
                        tabPage_Flag = 13;
                        tabControl1.SelectedIndex = 13;
                        lblCakeDerece.ForeColor = Color.Red;
                        lblCakeSaat.ForeColor = Color.White;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 40)       //Favoriler Cake Sayfası(Dakika)
                    {
                        tabPage_Flag = 13;
                        tabControl1.SelectedIndex = 13;
                        lblCakeDerece.ForeColor = Color.White;
                        lblCakeSaat.ForeColor = Color.Red;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 41)       //Favoriler Cookie Sayfası(Derece)
                    {
                        tabPage_Flag = 14;
                        tabControl1.SelectedIndex = 14;
                        lblCookieDerece.ForeColor = Color.Red;
                        lblCookieSaat.ForeColor = Color.White;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 42)       //Favoriler Cookie Sayfası(Dakika)
                    {
                        tabPage_Flag = 14;
                        tabControl1.SelectedIndex = 14;
                        lblCookieDerece.ForeColor = Color.White;
                        lblCookieSaat.ForeColor = Color.Red;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 43)       //Favoriler Pie Sayfası(Derece)
                    {
                        tabPage_Flag = 15;
                        tabControl1.SelectedIndex = 15;
                        lblPieDerece.ForeColor = Color.Red;
                        lblPieSaat.ForeColor = Color.White;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 44)       //Favoriler Pie Sayfası(Dakika)
                    {
                        tabPage_Flag = 15;
                        tabControl1.SelectedIndex = 15;
                        lblPieDerece.ForeColor = Color.White;
                        lblPieSaat.ForeColor = Color.Red;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 45)       //Favoriler Bread Sayfası(Derece)
                    {
                        tabPage_Flag = 16;
                        tabControl1.SelectedIndex = 16;
                        lblBreadDerece.ForeColor = Color.Red;
                        lblBreadDakika.ForeColor = Color.White;

                        oldMenüMod = menüMod;
                    }

                    if (menüMod == 46)       //Favoriler Bread Sayfası(Dakika)
                    {
                        tabPage_Flag = 16;
                        tabControl1.SelectedIndex = 16;
                        lblBreadDerece.ForeColor = Color.White;
                        lblBreadDakika.ForeColor = Color.Red;

                        oldMenüMod = menüMod;
                    }

                }

                if (menüMod == 5)
                {
                    lblTimer2_ZamanSaat.Text = Gelen_TimerFirstButtonSaat.ToString() + ":" + Gelen_TimerFirstButtonDk.ToString();
                    lblTimer2_ZamanSaat.Location = new System.Drawing.Point(610 ,190);
                    
                }
                if (menüMod == 6)
                {
                    lblTimer2_ZamanSaat.Text = Gelen_TimerSecondButtonSaat.ToString() + ":" + Gelen_TimerSecondButtonDk.ToString();
                    lblTimer2_ZamanSaat.Location = new System.Drawing.Point(610, 190);
                }

                if (menüMod == 7)
                {
                    lblTimer2_ZamanSaat.Text = Gelen_TimerThirdButtonSaat.ToString() + ":" + Gelen_TimerThirdButtonDk.ToString();
                    lblTimer2_ZamanSaat.Location = new System.Drawing.Point(610, 190);   
                }
                if (menüMod == 8)
                {
                        if (Gelen_SettingsEcoState == 0)
                        {
                            if (Language_Flag == false)
                            {
                                lblSettings2_Mode.Text = "OFF";
                                lblSettings2_Mode.Location = new System.Drawing.Point(640, 191);
                            }
                            if (Language_Flag == true)
                            {
                                lblSettings2_Mode.Text = "KAPALI";
                                lblSettings2_Mode.Location = new System.Drawing.Point(600, 191);
                            }

                        }
                        if (Gelen_SettingsEcoState == 1)
                        {
                            if (Language_Flag == false)
                            {
                                lblSettings2_Mode.Location = new System.Drawing.Point(650, 191);
                                lblSettings2_Mode.Text = "ON";
                            }
                            if (Language_Flag == true)
                            {
                                lblSettings2_Mode.Text = "AÇIK";
                                lblSettings2_Mode.Location = new System.Drawing.Point(640, 191);
                            }
                        }
                }

                if (menüMod == 9)
                {
                   
                    lblSettings2_Mode.Text = Gelen_SettingsClockSaat.ToString() + ":" + Gelen_SettingsClockDk.ToString();
                    lblSettings2_Mode.Location = new System.Drawing.Point(670, 191);
                        
                }
                if (menüMod == 10)
                {
                    lblSettings2_Mode.Text = Gelen_SettingsBuzzer.ToString();
                    lblSettings2_Mode.Location = new System.Drawing.Point(670, 191); 
                }
                if (menüMod == 11)
                {
                    lblSettings2_Mode.Text = Gelen_SettingsParlaklık.ToString();
                    lblSettings2_Mode.Location = new System.Drawing.Point(670, 191);
                }
                if (menüMod == 12)
                {
                 
                        if (Gelen_SettingsBluetooth == 0)
                        {
                            if (Language_Flag == false)
                            {
                                lblSettings2_Mode.Location = new System.Drawing.Point(670, 191);
                                lblSettings2_Mode.Text = "OFF";
                            }
                            if (Language_Flag == true)
                            {
                                lblSettings2_Mode.Location = new System.Drawing.Point(600, 191);
                                lblSettings2_Mode.Text = "KAPALI";
                            }
                            
                      }
                        if (Gelen_SettingsBluetooth == 1)
                        {
                            if (Language_Flag == false)
                            {
                                lblSettings2_Mode.Location = new System.Drawing.Point(670, 191);
                                lblSettings2_Mode.Text = "ON";
                            }
                            if (Language_Flag == true)
                            {
                                lblSettings2_Mode.Location = new System.Drawing.Point(620, 191);
                                lblSettings2_Mode.Text = "AÇIK";
                            }
               
                        }
                }
                if (menüMod == 13)
                {

                        if (Gelen_SettingsLanguage == 0)
                        {
                            Language_Flag = true;

                            //*****************************************Timer***************************************
                            label1.Text = "Zamanlayıcı";
                            label1.Size = new System.Drawing.Size(215, 56);
                            label1.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                            label1.Location = new System.Drawing.Point(557, 203);

                            lblTimer1.Text ="Girmek İçin";
                            lblTimer1.Location = new System.Drawing.Point(99, 120);

                            lblTimerForward.Text = "İleri Butonuna";
                            lblTimerForward.Location = new System.Drawing.Point(73, 212);

                            lblTimer1_2.Text = "Basınız";
                            lblTimer1_2.Location = new System.Drawing.Point(140, 309);


                            //******************************************Settins***************************************
                            label6.Text = "Ayarlar";
                            label6.Location = new System.Drawing.Point(526, 182);

                            lblSettingsPress.Text = "Girmek İçin";
                            lblSettingsPress.Location = new System.Drawing.Point(99, 120);

                            lblSettingsForward.Text = "İleri Butonuna";
                            lblSettingsForward.Location = new System.Drawing.Point(73, 212);

                            lblSettingsToEnter.Text = "Basınız";
                            lblSettingsToEnter.Location = new System.Drawing.Point(140, 309);


                            lblSettings2_Mode.Location = new System.Drawing.Point(650, 191);
                            lblSettings2_Mode.Text = "TR";
                            
                            btnSettings_Night.Text = "Gece Modu";
                            btnSettings_SleepTime.Text = "Uyku Süresi";
                            btnSettings_Temp.Text = "Sıcaklık Birimi";
                            btnSettings_Bright.Text = "Parlaklık";
                            btnSettings_Bluetooth.Text = "Bluetooth";
                            btnSettings_Language.Text = "Dil";
                            btnSettings_Economic.Text = "Ekonomik Mod";
                            btnSettings_Clock.Text = "Saat";
                            btnSettings_Sound.Text = "Ses";

                            //*****************************************Favoriler************************************
                            lblFavorites.Text = "Favoriler";
                            lblFavoritesPress.Text = "Girmek İçin İleri Butonuna Basınız";

                            lblmeat.Text = "Et";
                            lblchicken.Text = "Tavuk";
                            lblFish.Text = "Balık";
                            lblVegan.Text = "Sebzeler";
                            lblPaste.Text = "Hamur";
                            lblPizza.Text = "Pizza";
                            lblCake.Text = "Kek";
                            lblCookie.Text = "Kurabiye";
                            lnlPie.Text = "Turta";
                            lblBread.Text = "Ekmek";
                        }
                        if (Gelen_SettingsLanguage == 1)
                        {
                            Language_Flag = false;
                            lblSettings2_Mode.Location = new System.Drawing.Point(650, 191);
                            lblSettings2_Mode.Text = "ENG";
                            
                            btnSettings_Night.Text = "Night Mode";
                            btnSettings_SleepTime.Text = "Sleep Time";
                            btnSettings_Temp.Text = "Temp Unit";
                            btnSettings_Bright.Text = "Brightness";
                            btnSettings_Bluetooth.Text = "Bluetooth";
                            btnSettings_Language.Text = "Language";
                            btnSettings_Economic.Text = "Economic";
                            btnSettings_Clock.Text = "Clock";
                            btnSettings_Sound.Text = "Sound";

                            lblTimer1.Text = "Press";
                            lblTimer1.Location = new System.Drawing.Point(150, 120);
                       
                            lblTimerForward.Text = "Forward Button";

                            lblTimer1_2.Text = "to Enter";

                            lblSettingsPress.Text = "Press";
                            lblSettingsPress.Location = new System.Drawing.Point(150, 120);
                            lblSettingsForward.Text = "Forward Button";
                            lblSettingsToEnter.Text = "to Enter";

                            lblFavorites.Text = "Favorites";
                            lblFavoritesPress.Text = "Press Forward Button to Enter";

                            lblmeat.Text = "Meat";
                            lblchicken.Text = "Chicken";
                            lblFish.Text = "Fish";
                            lblVegan.Text = "Vegetables";
                            lblPaste.Text = "Paste";
                            lblPizza.Text = "Pizza";
                            lblCake.Text = "Cake";
                            lblCookie.Text = "Cookie";
                            lnlPie.Text = "Pie";
                            lblBread.Text = "Bread";
                        }
                   
                }
                if (menüMod == 14)
                {
                    
                        if (Gelen_SettingsNightMode == 0)
                        {
                            if (Language_Flag == false)
                            {
                                lblSettings2_Mode.Location = new System.Drawing.Point(650, 191);
                                lblSettings2_Mode.Text = "OFF";
                            }
                            if (Language_Flag == true)
                            {
                                lblSettings2_Mode.Location = new System.Drawing.Point(600, 191);
                                lblSettings2_Mode.Text = "KAPALI";
                            }

                        }
                        if (Gelen_SettingsNightMode == 1)
                        {
                            if (Language_Flag == false)
                            {
                                lblSettings2_Mode.Location = new System.Drawing.Point(650, 191);
                                lblSettings2_Mode.Text = "ON";
                            }
                            if (Language_Flag == true)
                            {
                                lblSettings2_Mode.Location = new System.Drawing.Point(640, 191);
                                lblSettings2_Mode.Text = "AÇIK";
                            }
                           
                        }
                   
                }
                if (menüMod == 15)
                {
                    lblSettings2_Mode.Location = new System.Drawing.Point(670, 191);
                    lblSettings2_Mode.Text = Gelen_SettingsSleepTime.ToString();

                }
                if (menüMod == 16)
                {
                 
                        if (Gelen_SettingsTempUnit == 0)
                        {
                            lblSettings2_Mode.Location = new System.Drawing.Point(670, 191);
                            lblGelenTemp.Text = Gelen_SıcaklıkDegeri.ToString() + "°C";
                            lblSettings2_Mode.Text = "°C";
                            Temp_unit_flag = 1;
                        }
                        if (Gelen_SettingsTempUnit == 1)
                        {
                            lblSettings2_Mode.Location = new System.Drawing.Point(670, 191);
                            lblGelenTemp.Text = Gelen_SıcaklıkDegeri.ToString() + "°F";
                            lblSettings2_Mode.Text = "°F";
                            Temp_unit_flag = 2;
                        }
                 
                }
                if (menüMod == 27)
                {
                    if (Gelen_HaziryemekSıcaklık != old_Gelen_HaziryemekSıcaklık)
                    {
                        lblmeatDerece.Text = Gelen_HaziryemekSıcaklık.ToString() + "°" ;    //Veri buraya bir kere giricek ilk seferde ne varsa onu yazıcak!! ikinci değiştiğinde yazmayacak.
                        old_Gelen_HaziryemekSıcaklık = Gelen_HaziryemekSıcaklık;
                    }
                }
                if (menüMod == 28)
                {
                    if (Gelen_HaziryemekSaat != old_Gelen_HaziryemekSaat)
                    {
                        lblmeatdakika.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekSaat = Gelen_HaziryemekSaat;
                    }
                    if (Gelen_HaziryemekDk != old_Gelen_HaziryemekDk)
                    {
                        lblmeatdakika.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekDk = Gelen_HaziryemekDk;
                    }
                }
                if (menüMod == 29)
                {
                    if (Gelen_HaziryemekSıcaklık != old_Gelen_HaziryemekSıcaklık)
                    {
                        lblchickenDerece.Text = Gelen_HaziryemekSıcaklık.ToString()+ "°";   //Veri buraya bir kere giricek ilk seferde ne varsa onu yazıcak!! ikinci değiştiğinde yazmayacak.
                        old_Gelen_HaziryemekSıcaklık = Gelen_HaziryemekSıcaklık;
                    }
                }
                if (menüMod == 30)
                {
                    if (Gelen_HaziryemekSaat != old_Gelen_HaziryemekSaat)
                    {
                        lblchickendakika.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekSaat = Gelen_HaziryemekSaat;
                    }
                    if (Gelen_HaziryemekDk != old_Gelen_HaziryemekDk)
                    {
                        lblchickendakika.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekDk = Gelen_HaziryemekDk;
                    }
                }
                if (menüMod == 31)
                {
                    if (Gelen_HaziryemekSıcaklık != old_Gelen_HaziryemekSıcaklık)
                    {
                        lblFishderece.Text = Gelen_HaziryemekSıcaklık.ToString() + "°";   //Veri buraya bir kere giricek ilk seferde ne varsa onu yazıcak!! ikinci değiştiğinde yazmayacak.
                        old_Gelen_HaziryemekSıcaklık = Gelen_HaziryemekSıcaklık;
                    }
                }
                if (menüMod == 32)
                {
                    if (Gelen_HaziryemekSaat != old_Gelen_HaziryemekSaat)
                    {
                        lblFishSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekSaat = Gelen_HaziryemekSaat;
                    }
                    if (Gelen_HaziryemekDk != old_Gelen_HaziryemekDk)
                    {
                        lblFishSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekDk = Gelen_HaziryemekDk;
                    }
                }
                if (menüMod == 33)
                {
                    if (Gelen_HaziryemekSıcaklık != old_Gelen_HaziryemekSıcaklık)
                    {
                        lblVeganDerece.Text = Gelen_HaziryemekSıcaklık.ToString() + "°";   //Veri buraya bir kere giricek ilk seferde ne varsa onu yazıcak!! ikinci değiştiğinde yazmayacak.
                        old_Gelen_HaziryemekSıcaklık = Gelen_HaziryemekSıcaklık;
                    }
                }
                if (menüMod == 34)
                {
                    if (Gelen_HaziryemekSaat != old_Gelen_HaziryemekSaat)
                    {
                        lblVeganSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekSaat = Gelen_HaziryemekSaat;
                    }
                    if (Gelen_HaziryemekDk != old_Gelen_HaziryemekDk)
                    {
                        lblVeganSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekDk = Gelen_HaziryemekDk;
                    }
                }
                if (menüMod == 35)
                {
                    if (Gelen_HaziryemekSıcaklık != old_Gelen_HaziryemekSıcaklık)
                    {
                        lblPasteDerece.Text = Gelen_HaziryemekSıcaklık.ToString() + "°";   //Veri buraya bir kere giricek ilk seferde ne varsa onu yazıcak!! ikinci değiştiğinde yazmayacak.
                        old_Gelen_HaziryemekSıcaklık = Gelen_HaziryemekSıcaklık;
                    }
                }
                if (menüMod == 36)
                {
                    if (Gelen_HaziryemekSaat != old_Gelen_HaziryemekSaat)
                    {
                        lblPasteSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekSaat = Gelen_HaziryemekSaat;
                    }
                    if (Gelen_HaziryemekDk != old_Gelen_HaziryemekDk)
                    {
                        lblPasteSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekDk = Gelen_HaziryemekDk;
                    }
                }
                if (menüMod == 37)
                {
                    if (Gelen_HaziryemekSıcaklık != old_Gelen_HaziryemekSıcaklık)
                    {
                        lblPizzaDerece.Text = Gelen_HaziryemekSıcaklık.ToString() + "°";   //Veri buraya bir kere giricek ilk seferde ne varsa onu yazıcak!! ikinci değiştiğinde yazmayacak.
                        old_Gelen_HaziryemekSıcaklık = Gelen_HaziryemekSıcaklık;
                    }
                }
                if (menüMod == 38)
                {
                    if (Gelen_HaziryemekSaat != old_Gelen_HaziryemekSaat)
                    {
                        lblPizzaSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekSaat = Gelen_HaziryemekSaat;
                    }
                    if (Gelen_HaziryemekDk != old_Gelen_HaziryemekDk)
                    {
                        lblPizzaSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekDk = Gelen_HaziryemekDk;
                    }
                }
                if (menüMod == 39)
                {
                    if (Gelen_HaziryemekSıcaklık != old_Gelen_HaziryemekSıcaklık)
                    {
                        lblCakeDerece.Text = Gelen_HaziryemekSıcaklık.ToString() + "°";   //Veri buraya bir kere giricek ilk seferde ne varsa onu yazıcak!! ikinci değiştiğinde yazmayacak.
                        old_Gelen_HaziryemekSıcaklık = Gelen_HaziryemekSıcaklık;
                    }
                }
                if (menüMod == 40)
                {
                    if (Gelen_HaziryemekSaat != old_Gelen_HaziryemekSaat)
                    {
                        lblCakeSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekSaat = Gelen_HaziryemekSaat;
                    }
                    if (Gelen_HaziryemekDk != old_Gelen_HaziryemekDk)
                    {
                        lblCakeSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekDk = Gelen_HaziryemekDk;
                    }
                }
                if (menüMod == 41)
                {
                    if (Gelen_HaziryemekSıcaklık != old_Gelen_HaziryemekSıcaklık)
                    {
                        lblCookieDerece.Text = Gelen_HaziryemekSıcaklık.ToString() + "°";   //Veri buraya bir kere giricek ilk seferde ne varsa onu yazıcak!! ikinci değiştiğinde yazmayacak.
                        old_Gelen_HaziryemekSıcaklık = Gelen_HaziryemekSıcaklık;
                    }
                }
                if (menüMod == 42)
                {
                    if (Gelen_HaziryemekSaat != old_Gelen_HaziryemekSaat)
                    {
                        lblCookieSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekSaat = Gelen_HaziryemekSaat;
                    }
                    if (Gelen_HaziryemekDk != old_Gelen_HaziryemekDk)
                    {
                        lblCookieSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekDk = Gelen_HaziryemekDk;
                    }
                }
                if (menüMod == 43)
                {
                    if (Gelen_HaziryemekSıcaklık != old_Gelen_HaziryemekSıcaklık)
                    {
                        lblPieDerece.Text = Gelen_HaziryemekSıcaklık.ToString() + "°";   //Veri buraya bir kere giricek ilk seferde ne varsa onu yazıcak!! ikinci değiştiğinde yazmayacak.
                        old_Gelen_HaziryemekSıcaklık = Gelen_HaziryemekSıcaklık;
                    }
                }
                if (menüMod == 44)
                {
                    if (Gelen_HaziryemekSaat != old_Gelen_HaziryemekSaat)
                    {
                        lblPieSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekSaat = Gelen_HaziryemekSaat;
                    }
                    if (Gelen_HaziryemekDk != old_Gelen_HaziryemekDk)
                    {
                        lblPieSaat.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekDk = Gelen_HaziryemekDk;
                    }
                }
                if (menüMod == 45)
                {
                    if (Gelen_HaziryemekSıcaklık != old_Gelen_HaziryemekSıcaklık)
                    {
                        lblBreadDerece.Text = Gelen_HaziryemekSıcaklık.ToString() + "°";   //Veri buraya bir kere giricek ilk seferde ne varsa onu yazıcak!! ikinci değiştiğinde yazmayacak.
                        old_Gelen_HaziryemekSıcaklık = Gelen_HaziryemekSıcaklık;
                    }
                }
                if (menüMod == 46)
                {
                    if (Gelen_HaziryemekSaat != old_Gelen_HaziryemekSaat)
                    {
                        lblBreadDakika.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekSaat = Gelen_HaziryemekSaat;
                    }
                    if (Gelen_HaziryemekDk != old_Gelen_HaziryemekDk)
                    {
                        lblBreadDakika.Text = Gelen_HaziryemekSaat.ToString() + ":" + Gelen_HaziryemekDk.ToString();
                        old_Gelen_HaziryemekDk = Gelen_HaziryemekDk;
                    }
                }
            }
        }
        #endregion

        #region Gelen Verilerin Circle Angelde Gösterilmesi
        private void gelenTemp_Function()           //Gelen sıcaklık değerini Sliderda göstermek için hazırlanan fonksiyon.
        {
            if (Data_Buffer == 0)               //Eğer gelen değer o ise Sliderin değerini 17 yap.
            {
                circleAnglePicker1.Value = 90;      //17 Aşağıda hazırladığımız aralık arasındaki bir sayı.

            }
            else if (Data_Buffer == 1)

            {
                circleAnglePicker1.Value = 10;
            }
            else if (Data_Buffer == 2)

            {
                circleAnglePicker1.Value = 1;
            }
            else if (Data_Buffer == 3)

            {
                circleAnglePicker1.Value = -7;
            }
            else if (Data_Buffer == 4)

            {
                circleAnglePicker1.Value = -13;
            }
            else if (Data_Buffer == 5)

            {
                circleAnglePicker1.Value = -19;
            }
            else if (Data_Buffer == 6)

            {
                circleAnglePicker1.Value = -26;
            }
            else if (Data_Buffer == 7)

            {
                circleAnglePicker1.Value = -34;
            }
            else if (Data_Buffer == 8)

            {
                circleAnglePicker1.Value = -42;
            }
            else if (Data_Buffer == 9)

            {
                circleAnglePicker1.Value = -50;
            }
            else if (Data_Buffer == 10)

            {
                circleAnglePicker1.Value = -57;
            }
            else if (Data_Buffer == 11)

            {
                circleAnglePicker1.Value = -63;
            }
            else if (Data_Buffer == 12)

            {
                circleAnglePicker1.Value = -69;
            }
            else if (Data_Buffer == 13)

            {
                circleAnglePicker1.Value = -76;
            }
            else if (Data_Buffer == 14)

            {
                circleAnglePicker1.Value = -82;
            }
            else if (Data_Buffer == 15)

            {
                circleAnglePicker1.Value = -90;
            }
            else if (Data_Buffer == 16)

            {
                circleAnglePicker1.Value = -96;
            }
            else if (Data_Buffer == 17)

            {
                circleAnglePicker1.Value = -102;
            }
            else if (Data_Buffer == 18)

            {
                circleAnglePicker1.Value = -108;
            }
            else if (Data_Buffer == 19)

            {
                circleAnglePicker1.Value = -115;
            }
            else if (Data_Buffer == 20)

            {
                circleAnglePicker1.Value = -122;
            }
            else if (Data_Buffer == 21)

            {
                circleAnglePicker1.Value = -127;
            }
            else if (Data_Buffer == 22)

            {
                circleAnglePicker1.Value = -133;
            }
            else if (Data_Buffer == 23)

            {
                circleAnglePicker1.Value = -139;
            }
            else if (Data_Buffer == 24)

            {
                circleAnglePicker1.Value = -144;
            }
            else if (Data_Buffer == 25)

            {
                circleAnglePicker1.Value = -150;
            }
            else if (Data_Buffer == 26)

            {
                circleAnglePicker1.Value = -157;
            }
            else if (Data_Buffer == 27)

            {
                circleAnglePicker1.Value = -163;
            }
            else if (Data_Buffer == 28)

            {
                circleAnglePicker1.Value = -169;
            }
            else if (Data_Buffer == 29)

            {
                circleAnglePicker1.Value = -177;
            }
            else if (Data_Buffer == 30)

            {
                circleAnglePicker1.Value = 174;
            }
            /*
            else if (Data_Buffer == 31)

            {
                circleAnglePicker1.Value = -138;
            }
            else if (Data_Buffer == 32)

            {
                circleAnglePicker1.Value = -143;
            }
            else if (Data_Buffer == 33)

            {
                circleAnglePicker1.Value = -148;
            }
            else if (Data_Buffer == 34)

            {
                circleAnglePicker1.Value = -153;
            }
            else if (Data_Buffer == 35)

            {
                circleAnglePicker1.Value = -158;
            }
            else if (Data_Buffer == 36)

            {
                circleAnglePicker1.Value = -163;
            }
            else if (Data_Buffer == 37)

            {
                circleAnglePicker1.Value = -168;
            }
            else if (Data_Buffer == 38)

            {
                circleAnglePicker1.Value = -173;
            }
            else if (Data_Buffer == 39)

            {
                circleAnglePicker1.Value = -177;
            }
            else if (Data_Buffer == 40)

            {
                circleAnglePicker1.Value = 175;
            }*/
        }
        #endregion
        #endregion

        #region Değer Gönderme Alanı
        private async void SendData_Function()
        {
            var writer = new DataWriter();

            string sendTxt = SendData_Buffer;

            byte[] bytes = Encoding.ASCII.GetBytes(sendTxt);

            foreach (byte b in bytes)
            {
                Console.WriteLine(b);
            }

            writer.WriteBytes(bytes);
            var services = result.Services;

            foreach (var service in services)
            {
                if (service.Uuid.ToString("N").Substring(4, 4) == HEART_RATE_SERVICE_ID)
                {
                    GattCharacteristicsResult characteristicsResult = await service.GetCharacteristicsAsync();

                    if (characteristicsResult.Status == GattCommunicationStatus.Success)
                    {
                        var characteristics = characteristicsResult.Characteristics;
                        foreach (var characteristic in characteristics)
                        {
                            GattCommunicationStatus writeResult;

                            writeResult = await characteristic.WriteValueAsync(writer.DetachBuffer());
                            if (writeResult == GattCommunicationStatus.Success)
                            {
                            }
                        }
                    }
                }
            }
        }
        #endregion

       

        #region CircleAngleFunction                   
        private void CircleAnglePicker_Functions()                      //Timer,Settings ve Fav menülerindeki Sliderlerin Fonksiyonu
        {
            if (Circle_Angle_Picker_Buffer <= 92 && Circle_Angle_Picker_Buffer > 88)            //Açı değeri 20 ile 15 atasında ise değeri 0 yap.
            {
                String_Circle_Angle_Buffer = "L0?";
                CircleAnglePickerBufferVeri = 0;
            }
            else if (Circle_Angle_Picker_Buffer <= 88 && Circle_Angle_Picker_Buffer > 78)         //Açı değeri 15 ile 9 atasında ise değeri 1 yap.
            {
                String_Circle_Angle_Buffer = "L1?";
                CircleAnglePickerBufferVeri = 1;
            }
            else if (Circle_Angle_Picker_Buffer <= 78 && Circle_Angle_Picker_Buffer > 68)
            {
                String_Circle_Angle_Buffer = "L2?";
                CircleAnglePickerBufferVeri = 2;
            }
            else if (Circle_Angle_Picker_Buffer <= 68 && Circle_Angle_Picker_Buffer > 58)
            {
                String_Circle_Angle_Buffer = "L3?";
                CircleAnglePickerBufferVeri = 3;
            }
            else if (Circle_Angle_Picker_Buffer <= 58 && Circle_Angle_Picker_Buffer > 48)
            {
                String_Circle_Angle_Buffer = "L4?";
                CircleAnglePickerBufferVeri = 4;
            }
            else if (Circle_Angle_Picker_Buffer <= 48 && Circle_Angle_Picker_Buffer > 38)
            {
                String_Circle_Angle_Buffer = "L5?";
                CircleAnglePickerBufferVeri = 5;
            }
            else if (Circle_Angle_Picker_Buffer <= 38 && Circle_Angle_Picker_Buffer > 28)
            {
                String_Circle_Angle_Buffer = "L6?";
                CircleAnglePickerBufferVeri = 6;
            }
            else if (Circle_Angle_Picker_Buffer <= 28 && Circle_Angle_Picker_Buffer > 18)
            {
                String_Circle_Angle_Buffer = "L7?";
                CircleAnglePickerBufferVeri = 7;
            }
            else if (Circle_Angle_Picker_Buffer <= 18 && Circle_Angle_Picker_Buffer > 10)
            {
                String_Circle_Angle_Buffer = "L8?";
                CircleAnglePickerBufferVeri = 8;
            }
            else if (Circle_Angle_Picker_Buffer <= 10 && Circle_Angle_Picker_Buffer > 4)
            {
                String_Circle_Angle_Buffer = "L9?";
                CircleAnglePickerBufferVeri = 9;
            }
            else if (Circle_Angle_Picker_Buffer <= 4 && Circle_Angle_Picker_Buffer > -4)
            {
                String_Circle_Angle_Buffer = "L10?";
                CircleAnglePickerBufferVeri = 10;
            }
            else if (Circle_Angle_Picker_Buffer <= -4 && Circle_Angle_Picker_Buffer > -14)
            {
                String_Circle_Angle_Buffer = "L11?";
                CircleAnglePickerBufferVeri = 11;
            }
            else if (Circle_Angle_Picker_Buffer <= -14 && Circle_Angle_Picker_Buffer > -24)
            {
                String_Circle_Angle_Buffer = "L12?";
                CircleAnglePickerBufferVeri = 12;
            }
            else if (Circle_Angle_Picker_Buffer <= -24 && Circle_Angle_Picker_Buffer > -34)

            {
                String_Circle_Angle_Buffer = "L13?";
                CircleAnglePickerBufferVeri = 13;
            }
            else if (Circle_Angle_Picker_Buffer <= -34 && Circle_Angle_Picker_Buffer > -44)
            {
                String_Circle_Angle_Buffer = "L14?";
                CircleAnglePickerBufferVeri = 14;
            }
            else if (Circle_Angle_Picker_Buffer <= -44 && Circle_Angle_Picker_Buffer > -54)
            {
                String_Circle_Angle_Buffer = "L15?";
                CircleAnglePickerBufferVeri = 15;
            }
            else if (Circle_Angle_Picker_Buffer <= -54 && Circle_Angle_Picker_Buffer > -64)
            {
                String_Circle_Angle_Buffer = "L16?";
                CircleAnglePickerBufferVeri = 16;
            }
            else if (Circle_Angle_Picker_Buffer <= -64 && Circle_Angle_Picker_Buffer > -74)
            {
                String_Circle_Angle_Buffer = "L17?";
                CircleAnglePickerBufferVeri = 17;
            }
            else if (Circle_Angle_Picker_Buffer <= -74 && Circle_Angle_Picker_Buffer > -80)
            {
                String_Circle_Angle_Buffer = "L18?";
                CircleAnglePickerBufferVeri = 18;
            }
            else if (Circle_Angle_Picker_Buffer <= -80 && Circle_Angle_Picker_Buffer > -88)
            {
                String_Circle_Angle_Buffer = "L19?";
                CircleAnglePickerBufferVeri = 19;
            }
            else if (Circle_Angle_Picker_Buffer <= -88 && Circle_Angle_Picker_Buffer > -93)
            {
                String_Circle_Angle_Buffer = "L20?";
                CircleAnglePickerBufferVeri = 20;
            }
            else if (Circle_Angle_Picker_Buffer <= -93 && Circle_Angle_Picker_Buffer > -103)
            {
                String_Circle_Angle_Buffer = "L21?";
                CircleAnglePickerBufferVeri = 21;
            }
            else if (Circle_Angle_Picker_Buffer <= -103 && Circle_Angle_Picker_Buffer > -113)
            {
                String_Circle_Angle_Buffer = "L22?";
                CircleAnglePickerBufferVeri = 22;
            }
            else if (Circle_Angle_Picker_Buffer <= -113 && Circle_Angle_Picker_Buffer > -123)
            {
                String_Circle_Angle_Buffer = "L23?";
                CircleAnglePickerBufferVeri = 23;
            }
            else if (Circle_Angle_Picker_Buffer <= -123 && Circle_Angle_Picker_Buffer > -133)
            {
                String_Circle_Angle_Buffer = "L24?";
                CircleAnglePickerBufferVeri = 24;
            }
            else if (Circle_Angle_Picker_Buffer <= -133 && Circle_Angle_Picker_Buffer > -143)
            {
                String_Circle_Angle_Buffer = "L25?";
                CircleAnglePickerBufferVeri = 25;
            }
            else if (Circle_Angle_Picker_Buffer <= -143 && Circle_Angle_Picker_Buffer > -153)
            {
                String_Circle_Angle_Buffer = "L26?";
                CircleAnglePickerBufferVeri = 26;
            }
            else if (Circle_Angle_Picker_Buffer <= -153 && Circle_Angle_Picker_Buffer > -163)
            {
                String_Circle_Angle_Buffer = "L27?";
                CircleAnglePickerBufferVeri = 27;
            }
            else if (Circle_Angle_Picker_Buffer <= -163 && Circle_Angle_Picker_Buffer > -170)
            {
                String_Circle_Angle_Buffer = "L28?";
                CircleAnglePickerBufferVeri = 28;
            }
            else if (Circle_Angle_Picker_Buffer <= -170 && Circle_Angle_Picker_Buffer > -176)
            {
                String_Circle_Angle_Buffer = "L29?";
                CircleAnglePickerBufferVeri = 29;
            }
            else if (Circle_Angle_Picker_Buffer <= -176 && Circle_Angle_Picker_Buffer > -180)
            {
                String_Circle_Angle_Buffer = "L30?";
                CircleAnglePickerBufferVeri = 30;
            }
            else if (Circle_Angle_Picker_Buffer <= 180 && Circle_Angle_Picker_Buffer > 176)
            {
                String_Circle_Angle_Buffer = "L30?";
                CircleAnglePickerBufferVeri = 30;
            }
            else if (Circle_Angle_Picker_Buffer <= 176 && Circle_Angle_Picker_Buffer > 166)
            {
                String_Circle_Angle_Buffer = "L31?";
                CircleAnglePickerBufferVeri = 31;
            }
            else if (Circle_Angle_Picker_Buffer <= 166 && Circle_Angle_Picker_Buffer > 156)
            {
                String_Circle_Angle_Buffer = "L32?";
                CircleAnglePickerBufferVeri = 32;
            }
            else if (Circle_Angle_Picker_Buffer <= 156 && Circle_Angle_Picker_Buffer > 146)
            {
                String_Circle_Angle_Buffer = "L33?";
                CircleAnglePickerBufferVeri = 33;
            }
            else if (Circle_Angle_Picker_Buffer <= 146 && Circle_Angle_Picker_Buffer > 136)
            {
                String_Circle_Angle_Buffer = "L34?";
                CircleAnglePickerBufferVeri = 34;
            }
            else if (Circle_Angle_Picker_Buffer <= 136 && Circle_Angle_Picker_Buffer > 126)
            {
                String_Circle_Angle_Buffer = "L35?";
                CircleAnglePickerBufferVeri = 35;
            }
            else if (Circle_Angle_Picker_Buffer <= 126 && Circle_Angle_Picker_Buffer > 116)
            {
                String_Circle_Angle_Buffer = "L36?";
                CircleAnglePickerBufferVeri = 36;
            }
            else if (Circle_Angle_Picker_Buffer <= 116 && Circle_Angle_Picker_Buffer > 110)
            {
                String_Circle_Angle_Buffer = "L37?";
                CircleAnglePickerBufferVeri = 37;
            }
            else if (Circle_Angle_Picker_Buffer <= 110 && Circle_Angle_Picker_Buffer > 103)
            {
                String_Circle_Angle_Buffer = "L38?";
                CircleAnglePickerBufferVeri = 38;
            }
            else if (Circle_Angle_Picker_Buffer <= 103 && Circle_Angle_Picker_Buffer > 97)
            {
                String_Circle_Angle_Buffer = "L39?";
                CircleAnglePickerBufferVeri = 39;
            }
            else if (Circle_Angle_Picker_Buffer <= 97 && Circle_Angle_Picker_Buffer > 92)
            {
                String_Circle_Angle_Buffer = "L40?";
                CircleAnglePickerBufferVeri = 40;
            }
            
        }

        #endregion

        #region Temperature
        private void btn_temp_Ana_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 1;
        }

        private void btnTemp_ileri_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 2;
            tabControl1.SelectedIndex = 2;   //Denme

            SendData_Buffer = "M2?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }

        #region Circle Angle Alanı
       
        private void circleAnglePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            

            if (circleAnglePicker1.Value <= 93 && circleAnglePicker1.Value > 87)            //Açı değeri 20 ile 15 atasında ise değeri 0 yap.
            {
                string_buffer_circle = "R0?";
                int_SendData_Buffer = 0;

            }
            else if (circleAnglePicker1.Value <= 12 && circleAnglePicker1.Value > 5)         //Açı değeri 15 ile 9 atasında ise değeri 1 yap.

            {
                string_buffer_circle = "R1?";
                int_SendData_Buffer = 1;
            }
            else if (circleAnglePicker1.Value <= 5 && circleAnglePicker1.Value > -4)

            {
                string_buffer_circle = "R2?";
                int_SendData_Buffer = 2;
            }
            else if (circleAnglePicker1.Value <= -4 && circleAnglePicker1.Value > -10)

            {
                string_buffer_circle = "R3?";
                int_SendData_Buffer = 3;
            }
            else if (circleAnglePicker1.Value <= -10 && circleAnglePicker1.Value > -16)

            {
                string_buffer_circle = "R4?";
                int_SendData_Buffer = 4;
            }
            else if (circleAnglePicker1.Value <= -16 && circleAnglePicker1.Value > -22)

            {
                string_buffer_circle = "R5?";
                int_SendData_Buffer = 5;
            }
            else if (circleAnglePicker1.Value <= -22 && circleAnglePicker1.Value > -29)

            {
                string_buffer_circle = "R6?";
                int_SendData_Buffer = 6;
            }
            else if (circleAnglePicker1.Value <= -29 && circleAnglePicker1.Value > -38)

            {
                string_buffer_circle = "R7?";
                int_SendData_Buffer = 7;
            }
            else if (circleAnglePicker1.Value <= -38 && circleAnglePicker1.Value > -46)

            {
                string_buffer_circle = "R8?";
                int_SendData_Buffer = 8;
            }
            else if (circleAnglePicker1.Value <= -46 && circleAnglePicker1.Value > -53)

            {
                string_buffer_circle = "R9?";
                int_SendData_Buffer = 9;
            }
            else if (circleAnglePicker1.Value <= -53 && circleAnglePicker1.Value > -60)

            {
                string_buffer_circle = "R10?";
                int_SendData_Buffer = 10;
            }
            else if (circleAnglePicker1.Value <= -60 && circleAnglePicker1.Value > -66)
            {
                string_buffer_circle = "R11?";
                int_SendData_Buffer = 11;

            }
            else if (circleAnglePicker1.Value <= -66 && circleAnglePicker1.Value > -72)

            {
                string_buffer_circle = "R12?";
                int_SendData_Buffer = 12;
            }
            else if (circleAnglePicker1.Value <= -72 && circleAnglePicker1.Value > -78)

            {
                string_buffer_circle = "R13?";
                int_SendData_Buffer = 13;
            }
            else if (circleAnglePicker1.Value <= -78 && circleAnglePicker1.Value > -84)

            {
                string_buffer_circle = "R14?";
                int_SendData_Buffer = 14;
            }
            else if (circleAnglePicker1.Value <= -84 && circleAnglePicker1.Value > -92)

            {
                string_buffer_circle = "R15?";
                int_SendData_Buffer = 15;
            }
            else if (circleAnglePicker1.Value <= -92 && circleAnglePicker1.Value > -98)

            {
                string_buffer_circle = "R16?";
                int_SendData_Buffer = 16;
            }
            else if (circleAnglePicker1.Value <= -98 && circleAnglePicker1.Value > -105)

            {
                string_buffer_circle = "R17?";
                int_SendData_Buffer = 17;
            }
            else if (circleAnglePicker1.Value <= -105 && circleAnglePicker1.Value > -111)

            {
                string_buffer_circle = "R18?";
                int_SendData_Buffer = 18;
            }
            else if (circleAnglePicker1.Value <= -111 && circleAnglePicker1.Value > -118)

            {
                string_buffer_circle = "R19?";
                int_SendData_Buffer = 19;
            }
            else if (circleAnglePicker1.Value <= -118 && circleAnglePicker1.Value > -124)

            {
                string_buffer_circle = "R20?";
                int_SendData_Buffer = 20;
            }
            else if (circleAnglePicker1.Value <= -124 && circleAnglePicker1.Value > -130)

            {
                string_buffer_circle = "R21?";
                int_SendData_Buffer = 21;
            }
            else if (circleAnglePicker1.Value <= -130 && circleAnglePicker1.Value > -136)

            {
                string_buffer_circle = "R22?";
                int_SendData_Buffer = 22;
            }
            else if (circleAnglePicker1.Value <= -136 && circleAnglePicker1.Value > -142)

            {
                string_buffer_circle = "R23?";
                int_SendData_Buffer = 23;
            }
            else if (circleAnglePicker1.Value <= -142 && circleAnglePicker1.Value > -147)

            {
                string_buffer_circle = "R24?";
                int_SendData_Buffer = 24;
            }
            else if (circleAnglePicker1.Value <= -147 && circleAnglePicker1.Value > -153)

            {
                string_buffer_circle = "R25?";
                int_SendData_Buffer = 25;
            }
            else if (circleAnglePicker1.Value <= -153 && circleAnglePicker1.Value > -160)

            {
                string_buffer_circle = "R26?";
                int_SendData_Buffer = 26;
            }
            else if (circleAnglePicker1.Value <= -160 && circleAnglePicker1.Value > -166)

            {
                string_buffer_circle = "R27?";
                int_SendData_Buffer = 27;
            }
            else if (circleAnglePicker1.Value <= -166 && circleAnglePicker1.Value > -172)

            {
                string_buffer_circle = "R28?";
                int_SendData_Buffer = 28;
            }
            else if (circleAnglePicker1.Value <= -172 && circleAnglePicker1.Value > -178)

            {
                string_buffer_circle = "R29?";
                int_SendData_Buffer = 29;
            }
            else if (circleAnglePicker1.Value <= -178 && circleAnglePicker1.Value > -180)

            {
                string_buffer_circle = "R30?";
                int_SendData_Buffer = 30;
            }
            else if (circleAnglePicker1.Value <= 180 && circleAnglePicker1.Value > 175)

            {
                string_buffer_circle = "R30?";
                int_SendData_Buffer = 30;
            }
         

            if (Circle_Angle_Veri_Flag == true)            //Mouseyi bırakır bırakmaz mouseup eventinde 0 geliyo veri göndermiyz.
            {
                if (int_SendData_Buffer != old_int_SendData_Buffer)
                {
                    SendData_Buffer = string_buffer_circle;
                    SendData_Function();
                    old_int_SendData_Buffer = int_SendData_Buffer;          //Timer Buffer Koyman gerekip gerekmediğini sor.
                }

            }




        }


        private void circleAnglePicker1_MouseUp_1(object sender, MouseEventArgs e)  //Mouseden elimizi çektiğimiz anda bu fonksiyona girer.
        {
            tabPage_Flag = 1;
            Circle_Angle_Veri_Flag = false;                 //Mouseyi bırakınca değer 0 olur ve değer circleda gösterilmeye başlar.

        }

        private void circleAnglePicker1_MouseMove_1(object sender, MouseEventArgs e)  //Alan belirlemek için oluşturduk.
        {
            tabPage_Flag = 1;
            if (circleAnglePicker1.Value >= 12 && circleAnglePicker1.Value < 80)        //Eğer değeri 20 ile 90 arasıında ise direk 20 ye geri gönder.
            {
                circleAnglePicker1.Value = 12;
            }
            if (circleAnglePicker1.Value >= 99 && circleAnglePicker1.Value < 174)
            {
                circleAnglePicker1.Value = 175;
            }

        }

        private void circleAnglePicker1_MouseDown_1(object sender, MouseEventArgs e)
        {
            Circle_Angle_Veri_Flag = true;             //Değer gönderirken gelen veri ile çakışmamaısı için  oku ttuğumuzda değeri 1 yapar ve gelen veri ekranda çizdirilmez.
        }

        #endregion

        #endregion

        #region Timer

        #region Timer Ana Sayfa
        private void btnTimer_ana_Click_1(object sender, EventArgs e)
        {
            tabPage_Flag = 3;               //Sleep Moda geçtiğinde hangi sayfaya gittiğini anlaması için.
            tabControl1.SelectedIndex = 3;      //Geçici

            SendData_Buffer = "M5?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }
        private void btn_Timer1_ileri_Click_1(object sender, EventArgs e)
        {
            tabPage_Flag = 4;
            tabControl1.SelectedIndex = 4;

            SendData_Buffer = "M3?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;        //Verileri okurken 1 saniyelik duraklama için.
        }
        #endregion

        #region Timer İkinci Sayfa
        private void btnTimer2_geri_Click_1(object sender, EventArgs e)
        {
           
            tabPage_Flag = 2;
            tabControl1.SelectedIndex = 2;
            btn_tmr_ha.ForeColor = Color.White;
            btnTimer2_Acook.ForeColor = Color.White;
            btn_tmr_Alarm.ForeColor = Color.White;

            SendData_Buffer = "M2?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }
        private void btn_tmr_ha_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 3;
            btn_tmr_ha.ForeColor = Color.Red;
            btnTimer2_Acook.ForeColor = Color.White;
            btn_tmr_Alarm.ForeColor = Color.White;

            SendData_Buffer = "M5?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }
        private void btnTimer2_Acook_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 3;
            btnTimer2_Acook.ForeColor = Color.Red;
            btn_tmr_ha.ForeColor = Color.White;
            btn_tmr_Alarm.ForeColor = Color.White;

            SendData_Buffer = "M6?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            
        }
        private void btn_tmr_Alarm_Click_1(object sender, EventArgs e)
        {
           
            tabPage_Flag = 3;
            btn_tmr_Alarm.ForeColor = Color.Red;
            btn_tmr_ha.ForeColor = Color.White;
            btnTimer2_Acook.ForeColor = Color.White;

            SendData_Buffer = "M7?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

        }
        #region TimerCircleAngle
        private void circleAnglePickerTimer_ValueChanged_1(object sender, EventArgs e)
        {
            Circle_Angle_Picker_Buffer = circleAnglePickerTimer.Value;
            CircleAnglePicker_Functions();
            String_Circle_Buffer_Timer = String_Circle_Angle_Buffer;

            

            if (Circle_Angle_Veri_Flag_Timer == true)            //Mouseyi bırakır bırakmaz mouseup eventinde 0 geliyo veri göndermiyz.
            {
                int_Circle_SendData_Buffer_Timer = CircleAnglePickerBufferVeri;         //Gelen veriyi burda eşitliyoruz.

                if (int_Circle_SendData_Buffer_Timer != old_int_Circle_SendData_Buffer_Timer)   //Fonksiyon Kontrol ediliyorAunı ise girmez.
                {
                    SendData_Buffer = String_Circle_Buffer_Timer;
                    SendData_Function();
                    old_int_Circle_SendData_Buffer_Timer = int_Circle_SendData_Buffer_Timer;          //Timer Buffer Koyman gerekip gerekmediğini sor.
                }

            }
        }

        private void circleAnglePickerTimer_MouseDown_1(object sender, MouseEventArgs e)
        {
            //TimeOut_Reset();
            Circle_Angle_Veri_Flag_Timer = true;
        }

        private void circleAnglePickerTimer_MouseUp_1(object sender, MouseEventArgs e)
        {
            //TimeOut_Reset();
            Circle_Angle_Veri_Flag_Timer = false;
        }
        #endregion

        #endregion

        #endregion

        #region Settings

        #region Settings Ana Sayfa
        private void btn_Setting_ileri_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 6;
            tabControl1.SelectedIndex = 6;

            SendData_Buffer = "M4?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }
        private void btn_Settings_Ana_Click_1(object sender, EventArgs e)
        {
            tabPage_Flag = 5;
            tabControl1.SelectedIndex = 5;

            SendData_Buffer = "M8?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }

        #endregion

        #region Settings İkinci Sayfa
        private void btnSettins2_geri_Click_1(object sender, EventArgs e)
        {
            tabPage_Flag = 4;
            tabControl1.SelectedIndex = 4;
            btnSettings_Night.ForeColor = Color.White;
            btnSettings_SleepTime.ForeColor = Color.White;
            btnSettings_Temp.ForeColor = Color.White;
            btnSettings_Bright.ForeColor = Color.White;
            btnSettings_Bluetooth.ForeColor = Color.White;
            btnSettings_Language.ForeColor = Color.White;
            btnSettings_Economic.ForeColor = Color.White;
            btnSettings_Clock.ForeColor = Color.White;
            btnSettings_Sound.ForeColor = Color.White;

            SendData_Buffer = "M3?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }
        private void btnSettings_Economic_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 5;
            btnSettings_Night.ForeColor = Color.White;
            btnSettings_SleepTime.ForeColor = Color.White;
            btnSettings_Temp.ForeColor = Color.White;
            btnSettings_Bright.ForeColor = Color.White;
            btnSettings_Bluetooth.ForeColor = Color.White;
            btnSettings_Language.ForeColor = Color.White;
            btnSettings_Economic.ForeColor = Color.Red;
            btnSettings_Clock.ForeColor = Color.White;
            btnSettings_Sound.ForeColor = Color.White;

            SendData_Buffer = "M8?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;            
        }
        private void btnSettings_Clock_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 5;
            btnSettings_Night.ForeColor = Color.White;
            btnSettings_SleepTime.ForeColor = Color.White;
            btnSettings_Temp.ForeColor = Color.White;
            btnSettings_Bright.ForeColor = Color.White;
            btnSettings_Bluetooth.ForeColor = Color.White;
            btnSettings_Language.ForeColor = Color.White;
            btnSettings_Economic.ForeColor = Color.White;
            btnSettings_Clock.ForeColor = Color.Red;
            btnSettings_Sound.ForeColor = Color.White;

            SendData_Buffer = "M9?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }
        private void btnSettings_Sound_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 5;
            btnSettings_Night.ForeColor = Color.White;
            btnSettings_SleepTime.ForeColor = Color.White;
            btnSettings_Temp.ForeColor = Color.White;
            btnSettings_Bright.ForeColor = Color.White;
            btnSettings_Bluetooth.ForeColor = Color.White;
            btnSettings_Language.ForeColor = Color.White;
            btnSettings_Economic.ForeColor = Color.White;
            btnSettings_Clock.ForeColor = Color.White;
            btnSettings_Sound.ForeColor = Color.Red;

            SendData_Buffer = "M10?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }
        private void btnSettings_Bright_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 5;
            btnSettings_Night.ForeColor = Color.White;
            btnSettings_SleepTime.ForeColor = Color.White;
            btnSettings_Temp.ForeColor = Color.White;
            btnSettings_Bright.ForeColor = Color.Red;
            btnSettings_Bluetooth.ForeColor = Color.White;
            btnSettings_Language.ForeColor = Color.White;
            btnSettings_Economic.ForeColor = Color.White;
            btnSettings_Clock.ForeColor = Color.White;
            btnSettings_Sound.ForeColor = Color.White;

            SendData_Buffer = "M11?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }
        private void btnSettings_Bluetooth_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 5;
            btnSettings_Night.ForeColor = Color.White;
            btnSettings_SleepTime.ForeColor = Color.White;
            btnSettings_Temp.ForeColor = Color.White;
            btnSettings_Bright.ForeColor = Color.White;
            btnSettings_Bluetooth.ForeColor = Color.Red;
            btnSettings_Language.ForeColor = Color.White;
            btnSettings_Economic.ForeColor = Color.White;
            btnSettings_Clock.ForeColor = Color.White;
            btnSettings_Sound.ForeColor = Color.White;

            SendData_Buffer = "M12?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }
        private void btnSettings_Language_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 5;
            btnSettings_Night.ForeColor = Color.White;
            btnSettings_SleepTime.ForeColor = Color.White;
            btnSettings_Temp.ForeColor = Color.White;
            btnSettings_Bright.ForeColor = Color.White;
            btnSettings_Bluetooth.ForeColor = Color.White;
            btnSettings_Language.ForeColor = Color.Red;
            btnSettings_Economic.ForeColor = Color.White;
            btnSettings_Clock.ForeColor = Color.White;
            btnSettings_Sound.ForeColor = Color.White;

            SendData_Buffer = "M13?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }
        private void btnSettings_Night_Click_1(object sender, EventArgs e)
        {
          
            tabPage_Flag = 5;
            btnSettings_Night.ForeColor = Color.Red;
            btnSettings_SleepTime.ForeColor = Color.White;
            btnSettings_Temp.ForeColor = Color.White;
            btnSettings_Bright.ForeColor = Color.White;
            btnSettings_Bluetooth.ForeColor = Color.White;
            btnSettings_Language.ForeColor = Color.White;
            btnSettings_Economic.ForeColor = Color.White;
            btnSettings_Clock.ForeColor = Color.White;
            btnSettings_Sound.ForeColor = Color.White;

            SendData_Buffer = "M14?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }
        private void btnSettings_SleepTime_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 5;
            btnSettings_Night.ForeColor = Color.White;
            btnSettings_SleepTime.ForeColor = Color.Red;
            btnSettings_Temp.ForeColor = Color.White;
            btnSettings_Bright.ForeColor = Color.White;
            btnSettings_Bluetooth.ForeColor = Color.White;
            btnSettings_Language.ForeColor = Color.White;
            btnSettings_Economic.ForeColor = Color.White;
            btnSettings_Clock.ForeColor = Color.White;
            btnSettings_Sound.ForeColor = Color.White;

            SendData_Buffer = "M15?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }
        private void btnSettings_Temp_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 5;
            btnSettings_Night.ForeColor = Color.White;
            btnSettings_SleepTime.ForeColor = Color.White;
            btnSettings_Temp.ForeColor = Color.Red;
            btnSettings_Bright.ForeColor = Color.White;
            btnSettings_Bluetooth.ForeColor = Color.White;
            btnSettings_Language.ForeColor = Color.White;
            btnSettings_Economic.ForeColor = Color.White;
            btnSettings_Clock.ForeColor = Color.White;
            btnSettings_Sound.ForeColor = Color.White;

            SendData_Buffer = "M16?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }

        #region SettingsCircleAngle
        private void circleAnglePickerSettings_ValueChanged_1(object sender, EventArgs e)
        {
            Circle_Angle_Picker_Buffer = circleAnglePickerSettings.Value;       //Value bir değişkene aktarılıyor.
            CircleAnglePicker_Functions();                                      //Değişken fonksiyonda işleniyor ve değerler ayarlanıyor.
            String_Circle_Buffer_Settings = String_Circle_Angle_Buffer;         //Fonksiyondaki değer Settings Değişkenine aktarılıyor ve Gönderime hazır hale geliyor.
            


            if (Circle_Angle_Veri_Flag_Settings == true)            //Mouseyi bırakır bırakmaz mouseup eventinde false geliyo veri göndermiyz.
            {
                int_Circle_SendData_Buffer_Settings = CircleAnglePickerBufferVeri;         //Gelen veriyi burda eşitliyoruz.

                if (int_Circle_SendData_Buffer_Settings != old_int_Circle_SendData_Buffer_Settings)   //Fonksiyon Kontrol ediliyorAunı ise girmez.
                {
                    SendData_Buffer = String_Circle_Buffer_Settings;
                    SendData_Function();
                    old_int_Circle_SendData_Buffer_Settings = int_Circle_SendData_Buffer_Settings;          //Timer Buffer Koyman gerekip gerekmediğini sor.
                }

            }
        }

        private void circleAnglePickerSettings_MouseDown_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Settings = true;
        }

        private void circleAnglePickerSettings_MouseUp_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Settings = false;
        }
        #endregion

        #endregion

        #endregion

        #region Favorites Menüsü
        
        private void btn_Fav1_ileri_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 1;
            tabControl1.SelectedIndex = 1;

            SendData_Buffer = "M1?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }
        private void btn_fav1_Ana_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 7;
            tabControl1.SelectedIndex = 7;

            SendData_Buffer = "M17?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
        }

        #region Meat
        private void btn_favmeat_ileri_Click_1(object sender, EventArgs e)
        {
            
            lblmeatDerece.ForeColor = Color.White;
            lblmeatdakika.ForeColor = Color.White;
            tabPage_Flag = 8;
            tabControl1.SelectedIndex = 8;

            SendData_Buffer = "M18?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
            circleAnglePicker_Meat.Visible = false;
        }
        private void btn_favmeat_geri_Click_1(object sender, EventArgs e)
        {
           
            tabPage_Flag = 6;
            tabControl1.SelectedIndex = 6;
            lblmeatDerece.ForeColor = Color.White;
            lblmeatdakika.ForeColor = Color.White;

            SendData_Buffer = "M4?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Meat.Visible = false;
        }

        private void lblmeatDerece_MouseClick_1(object sender, MouseEventArgs e)
        {
            lblmeatDerece.ForeColor = Color.Red;
            lblmeatdakika.ForeColor = Color.White;

            SendData_Buffer = "M27?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Meat.Visible = true;
        }
        private void lblmeatdakika_MouseClick_1(object sender, MouseEventArgs e)
        {
            lblmeatDerece.ForeColor = Color.White;
            lblmeatdakika.ForeColor = Color.Red;

            SendData_Buffer = "M28?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Meat.Visible = true;
        }
        #region Circle Angle
        private void circleAnglePicker_Meat_ValueChanged_1(object sender, EventArgs e)
        {
            Circle_Angle_Picker_Buffer = circleAnglePicker_Meat.Value;       //Value bir değişkene aktarılıyor.
            CircleAnglePicker_Functions();                                      //Değişken fonksiyonda işleniyor ve değerler ayarlanıyor.
            String_Circle_Buffer_Meat = String_Circle_Angle_Buffer;         //Fonksiyondaki değer Settings Değişkenine aktarılıyor ve Gönderime hazır hale geliyor.
            

            if (Circle_Angle_Veri_Flag_Meat == true)            //Mouseyi bırakır bırakmaz mouseup eventinde false geliyo veri göndermiyz.
            {
                int_Circle_SendData_Buffer_Meat = CircleAnglePickerBufferVeri;         //Gelen veriyi burda eşitliyoruz.

                if (int_Circle_SendData_Buffer_Meat != old_int_Circle_SendData_Buffer_Meat)   //Fonksiyon Kontrol ediliyorAunı ise girmez.
                {
                    SendData_Buffer = String_Circle_Buffer_Meat;
                    SendData_Function();
                    old_int_Circle_SendData_Buffer_Meat = int_Circle_SendData_Buffer_Meat;          //Timer Buffer Koyman gerekip gerekmediğini sor.
                }
            }
        }

        private void circleAnglePicker_Meat_MouseDown_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Meat = true;
        }

        private void circleAnglePicker_Meat_MouseUp_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Meat = false;
        }
        #endregion
        #endregion

        #region Chicken
        private void btn_favchicken_ileri_Click_1(object sender, EventArgs e)
        {
            
            lblchickenDerece.ForeColor = Color.White;
            lblchickendakika.ForeColor = Color.White;
            tabPage_Flag = 9;
            tabControl1.SelectedIndex = 9;

            SendData_Buffer = "M19?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
            circleAnglePicker_Chicken.Visible = false;
        }
        private void btn_favchicken_geri_Click_1(object sender, EventArgs e)
        {
            
            lblchickenDerece.ForeColor = Color.White;
            lblchickendakika.ForeColor = Color.White;
            tabPage_Flag = 6;
            tabControl1.SelectedIndex = 6;

            SendData_Buffer = "M4?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Chicken.Visible = false;
        }
        private void lblchickenDerece_Click_1(object sender, EventArgs e)
        {
            
            lblchickenDerece.ForeColor = Color.Red;
            lblchickendakika.ForeColor = Color.White;
            tabPage_Flag = 8;

            SendData_Buffer = "M29?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Chicken.Visible = true;
        }
        private void lblchickendakika_Click_1(object sender, EventArgs e)
        {
           
            lblchickendakika.ForeColor = Color.Red;
            lblchickenDerece.ForeColor = Color.White;
            tabPage_Flag = 8;

            SendData_Buffer = "M30?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Chicken.Visible = true;
        }

        #region Circle Angle
        private void circleAnglePicker_Chicken_ValueChanged_1(object sender, EventArgs e)
        {
            Circle_Angle_Picker_Buffer = circleAnglePicker_Chicken.Value;       //Value bir değişkene aktarılıyor.
            CircleAnglePicker_Functions();                                      //Değişken fonksiyonda işleniyor ve değerler ayarlanıyor.
            String_Circle_Buffer_Chicken = String_Circle_Angle_Buffer;         //Fonksiyondaki değer Settings Değişkenine aktarılıyor ve Gönderime hazır hale geliyor.

            if (Circle_Angle_Veri_Flag_Chicken == true)            //Mouseyi bırakır bırakmaz mouseup eventinde false geliyo veri göndermiyz.
            {
                int_Circle_SendData_Buffer_Chicken = CircleAnglePickerBufferVeri;         //Gelen veriyi burda eşitliyoruz.

                if (int_Circle_SendData_Buffer_Chicken != old_int_Circle_SendData_Buffer_Chicken)   //Fonksiyon Kontrol ediliyorAunı ise girmez.
                {
                    SendData_Buffer = String_Circle_Buffer_Chicken;
                    SendData_Function();
                    old_int_Circle_SendData_Buffer_Chicken = int_Circle_SendData_Buffer_Chicken;          //Timer Buffer Koyman gerekip gerekmediğini sor.
                }
            }
        }
        private void circleAnglePicker_Chicken_MouseDown_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Chicken = true;
        }
        private void circleAnglePicker_Chicken_MouseUp_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Chicken = false;
        }
        #endregion

        #endregion

        #region Fish
        private void btn_favFish2_ileri_Click_1(object sender, EventArgs e)
        {
           
            lblFishderece.ForeColor = Color.White;
            lblFishSaat.ForeColor = Color.White;
            tabPage_Flag = 10;
            tabControl1.SelectedIndex = 10;

            SendData_Buffer = "M20?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Fish.Visible = false;
        }

        private void btn_favfish2_geri_Click_1(object sender, EventArgs e)
        {
           
            lblFishderece.ForeColor = Color.White;
            lblFishSaat.ForeColor = Color.White;
            tabPage_Flag = 6;
            tabControl1.SelectedIndex = 6;

            SendData_Buffer = "M4?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Fish.Visible = false;
        }
        private void lblFishderece_Click(object sender, EventArgs e)
        {
            
            tabPage_Flag = 9;
            lblFishderece.ForeColor = Color.Red;
            lblFishSaat.ForeColor = Color.White;

            SendData_Buffer = "M31?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Fish.Visible = true;
        }
        private void lblFishSaat_Click(object sender, EventArgs e)
        {
            
            tabPage_Flag = 9;
            lblFishderece.ForeColor = Color.White;
            lblFishSaat.ForeColor = Color.Red;

            SendData_Buffer = "M32?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Fish.Visible = true;
        }

        #region Circle Angle
        private void circleAnglePicker_Fish_ValueChanged_1(object sender, EventArgs e)
        {
            Circle_Angle_Picker_Buffer = circleAnglePicker_Fish.Value;       //Value bir değişkene aktarılıyor.
            CircleAnglePicker_Functions();                                      //Değişken fonksiyonda işleniyor ve değerler ayarlanıyor.
            String_Circle_Buffer_Fish = String_Circle_Angle_Buffer;         //Fonksiyondaki değer Settings Değişkenine aktarılıyor ve Gönderime hazır hale geliyor.

            if (Circle_Angle_Veri_Flag_Fish == true)            //Mouseyi bırakır bırakmaz mouseup eventinde false geliyo veri göndermiyz.
            {
                int_Circle_SendData_Buffer_Fish = CircleAnglePickerBufferVeri;         //Gelen veriyi burda eşitliyoruz.

                if (int_Circle_SendData_Buffer_Fish != old_int_Circle_SendData_Buffer_Fish)   //Fonksiyon Kontrol ediliyorAunı ise girmez.
                {
                    SendData_Buffer = String_Circle_Buffer_Fish;
                    SendData_Function();
                    old_int_Circle_SendData_Buffer_Fish = int_Circle_SendData_Buffer_Fish;          //Timer Buffer Koyman gerekip gerekmediğini sor.
                }
            }
        }
        private void circleAnglePicker_Fish_MouseDown_1(object sender, MouseEventArgs e)
        {
           
            Circle_Angle_Veri_Flag_Fish = true;
        }
        private void circleAnglePicker_Fish_MouseUp_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Fish = false;
        }
        #endregion
        #endregion

        #region Vegan
        private void btn_FavVegan_ileri_Click_1(object sender, EventArgs e)
        {
            
            lblVeganDerece.ForeColor = Color.White;
            lblVeganSaat.ForeColor = Color.White;
            tabPage_Flag = 11;
            tabControl1.SelectedIndex = 11;

            SendData_Buffer = "M21?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Vegan.Visible = false;
        }
        private void btn_FavVegan2_geri_Click_1(object sender, EventArgs e)
        {
          
            lblVeganDerece.ForeColor = Color.White;
            lblVeganSaat.ForeColor = Color.White;
            tabPage_Flag = 6;
            tabControl1.SelectedIndex = 6;

            SendData_Buffer = "M4?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Vegan.Visible = false;
        }
        private void lblVeganDerece_Click(object sender, EventArgs e)
        {
            
            tabPage_Flag = 10;
            lblVeganDerece.ForeColor = Color.Red;
            lblVeganSaat.ForeColor = Color.White;

            SendData_Buffer = "M33?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Vegan.Visible = true;
        }

        private void lblVeganSaat_Click(object sender, EventArgs e)
        {
            
            tabPage_Flag = 10;
            lblVeganDerece.ForeColor = Color.White;
            lblVeganSaat.ForeColor = Color.Red;

            SendData_Buffer = "M34?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Vegan.Visible = true;
        }

        #region Circle Angle
        private void circleAnglePicker_Vegan_ValueChanged_1(object sender, EventArgs e)
        {
            Circle_Angle_Picker_Buffer = circleAnglePicker_Vegan.Value;       //Value bir değişkene aktarılıyor.
            CircleAnglePicker_Functions();                                      //Değişken fonksiyonda işleniyor ve değerler ayarlanıyor.
            String_Circle_Buffer_Vegan = String_Circle_Angle_Buffer;         //Fonksiyondaki değer Settings Değişkenine aktarılıyor ve Gönderime hazır hale geliyor.

            if (Circle_Angle_Veri_Flag_Vegan == true)            //Mouseyi bırakır bırakmaz mouseup eventinde false geliyo veri göndermiyz.
            {
                int_Circle_SendData_Buffer_Vegan = CircleAnglePickerBufferVeri;         //Gelen veriyi burda eşitliyoruz.

                if (int_Circle_SendData_Buffer_Vegan != old_int_Circle_SendData_Buffer_Vegan)   //Fonksiyon Kontrol ediliyorAunı ise girmez.
                {
                    SendData_Buffer = String_Circle_Buffer_Vegan;
                    SendData_Function();
                    old_int_Circle_SendData_Buffer_Vegan = int_Circle_SendData_Buffer_Vegan;          //Timer Buffer Koyman gerekip gerekmediğini sor.
                }
            }
        }
        private void circleAnglePicker_Vegan_MouseDown_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Vegan = true;
        }
        private void circleAnglePicker_Vegan_MouseUp_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Vegan = true;
        }

        #endregion

        #endregion

        #region Paste
        private void btn_FavPaste_ileri_Click_1(object sender, EventArgs e)
        {
            
            lblPasteDerece.ForeColor = Color.White;
            lblPasteSaat.ForeColor = Color.White;
            tabPage_Flag = 12;
            tabControl1.SelectedIndex = 12;

            SendData_Buffer = "M22?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Paste.Visible = false;
        }

        private void btn_FavPaste_geri_Click_1(object sender, EventArgs e)
        {
            
            lblPasteDerece.ForeColor = Color.White;
            lblPasteSaat.ForeColor = Color.White;
            tabPage_Flag = 6;
            tabControl1.SelectedIndex = 6;

            SendData_Buffer = "M4?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Paste.Visible = false;
        }
        private void lblPasteDerece_Click(object sender, EventArgs e)
        {
           
            tabPage_Flag = 11;
            lblPasteDerece.ForeColor = Color.Red;
            lblPasteSaat.ForeColor = Color.White;

            SendData_Buffer = "M35?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Paste.Visible = true;
        }
        private void lblPasteSaat_Click(object sender, EventArgs e)
        {
           
            tabPage_Flag = 11;
            lblPasteDerece.ForeColor = Color.White;
            lblPasteSaat.ForeColor = Color.Red;

            SendData_Buffer = "M36?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Paste.Visible = true;
        }

        #region Circle Angle
        private void circleAnglePicker_Paste_ValueChanged_1(object sender, EventArgs e)
        {
            Circle_Angle_Picker_Buffer = circleAnglePicker_Paste.Value;       //Value bir değişkene aktarılıyor.
            CircleAnglePicker_Functions();                                      //Değişken fonksiyonda işleniyor ve değerler ayarlanıyor.
            String_Circle_Buffer_Paste = String_Circle_Angle_Buffer;         //Fonksiyondaki değer Settings Değişkenine aktarılıyor ve Gönderime hazır hale geliyor.

            if (Circle_Angle_Veri_Flag_Paste == true)            //Mouseyi bırakır bırakmaz mouseup eventinde false geliyo veri göndermiyz.
            {
                int_Circle_SendData_Buffer_Paste = CircleAnglePickerBufferVeri;         //Gelen veriyi burda eşitliyoruz.

                if (int_Circle_SendData_Buffer_Paste != old_int_Circle_SendData_Buffer_Paste)   //Fonksiyon Kontrol ediliyorAunı ise girmez.
                {
                    SendData_Buffer = String_Circle_Buffer_Paste;
                    SendData_Function();
                    old_int_Circle_SendData_Buffer_Paste = int_Circle_SendData_Buffer_Paste;          //Timer Buffer Koyman gerekip gerekmediğini sor.
                }
            }
        }
        private void circleAnglePicker_Paste_MouseDown_1(object sender, MouseEventArgs e)
        {
           
            Circle_Angle_Veri_Flag_Paste = true;
        }
        private void circleAnglePicker_Paste_MouseUp_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Paste = false;
        }
        #endregion
        #endregion

        #region Pizza 
        private void btn_FavPizza_ileri_Click_1(object sender, EventArgs e)
        {
           
            lblPizzaDerece.ForeColor = Color.White;
            lblPizzaSaat.ForeColor = Color.White;
            tabPage_Flag = 13;
            tabControl1.SelectedIndex = 13;

            SendData_Buffer = "M23?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Pizza.Visible = false;
        }

        private void btn_FavPizza_geri_Click_1(object sender, EventArgs e)
        {
           
            lblPizzaDerece.ForeColor = Color.White;
            lblPizzaSaat.ForeColor = Color.White;
            tabPage_Flag = 6;
            tabControl1.SelectedIndex = 6;

            SendData_Buffer = "M4?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Pizza.Visible = false;
        }
        private void lblPizzaDerece_Click(object sender, EventArgs e)
        {
            
            tabPage_Flag = 12;
            lblPizzaDerece.ForeColor = Color.Red;
            lblPizzaSaat.ForeColor = Color.White;

            SendData_Buffer = "M37?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Pizza.Visible = true;
        }
        private void lblPizzaSaat_Click(object sender, EventArgs e)
        {
            
            tabPage_Flag = 12;
            lblPizzaDerece.ForeColor = Color.White;
            lblPizzaSaat.ForeColor = Color.Red;

            SendData_Buffer = "M38?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Pizza.Visible = true;
        }
        #region Circle Angle
        private void circleAnglePicker_Pizza_ValueChanged_1(object sender, EventArgs e)
        {
            Circle_Angle_Picker_Buffer = circleAnglePicker_Pizza.Value;       //Value bir değişkene aktarılıyor.
            CircleAnglePicker_Functions();                                      //Değişken fonksiyonda işleniyor ve değerler ayarlanıyor.
            String_Circle_Buffer_Pizza = String_Circle_Angle_Buffer;         //Fonksiyondaki değer Settings Değişkenine aktarılıyor ve Gönderime hazır hale geliyor.

            if (Circle_Angle_Veri_Flag_Pizza == true)            //Mouseyi bırakır bırakmaz mouseup eventinde false geliyo veri göndermiyz.
            {
                int_Circle_SendData_Buffer_Pizza = CircleAnglePickerBufferVeri;         //Gelen veriyi burda eşitliyoruz.

                if (int_Circle_SendData_Buffer_Pizza != old_int_Circle_SendData_Buffer_Pizza)   //Fonksiyon Kontrol ediliyorAunı ise girmez.
                {
                    SendData_Buffer = String_Circle_Buffer_Pizza;
                    SendData_Function();
                    old_int_Circle_SendData_Buffer_Pizza = int_Circle_SendData_Buffer_Pizza;          //Timer Buffer Koyman gerekip gerekmediğini sor.
                }
            }
        }
        private void circleAnglePicker_Pizza_MouseDown_1(object sender, MouseEventArgs e)
        {
           
            Circle_Angle_Veri_Flag_Pizza = true;
        }
        private void circleAnglePicker_Pizza_MouseUp_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Pizza = false;
        }
        #endregion
        #endregion

        #region Cake
        private void btn_FavCake_ileri_Click_1(object sender, EventArgs e)
        {
           
            lblCakeDerece.ForeColor = Color.White;
            lblCakeSaat.ForeColor = Color.White;
            tabPage_Flag = 14;
            tabControl1.SelectedIndex = 14;

            SendData_Buffer = "M24?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Cake.Visible = false;
        }
        private void btn_FavCake_geri_Click_1(object sender, EventArgs e)
        {
           
            lblCakeDerece.ForeColor = Color.White;
            lblCakeSaat.ForeColor = Color.White;
            tabPage_Flag = 6;
            tabControl1.SelectedIndex = 6;

            SendData_Buffer = "M4?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Cake.Visible = false;
        }
        private void lblCakeDerece_Click(object sender, EventArgs e)
        {
           
            tabPage_Flag = 13;
            lblCakeDerece.ForeColor = Color.Red;
            lblCakeSaat.ForeColor = Color.White;

            SendData_Buffer = "M39?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Cake.Visible = true;
        }
        private void lblCakeSaat_Click(object sender, EventArgs e)
        {
            
            tabPage_Flag = 13;
            lblCakeDerece.ForeColor = Color.White;
            lblCakeSaat.ForeColor = Color.Red;

            SendData_Buffer = "M40?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Cake.Visible = true;
        }

        #region Circle Angle
        private void circleAnglePicker_Cake_ValueChanged_1(object sender, EventArgs e)
        {
            Circle_Angle_Picker_Buffer = circleAnglePicker_Cake.Value;       //Value bir değişkene aktarılıyor.
            CircleAnglePicker_Functions();                                      //Değişken fonksiyonda işleniyor ve değerler ayarlanıyor.
            String_Circle_Buffer_Cake = String_Circle_Angle_Buffer;         //Fonksiyondaki değer Settings Değişkenine aktarılıyor ve Gönderime hazır hale geliyor.

            if (Circle_Angle_Veri_Flag_Cake == true)            //Mouseyi bırakır bırakmaz mouseup eventinde false geliyo veri göndermiyz.
            {
                int_Circle_SendData_Buffer_Cake = CircleAnglePickerBufferVeri;         //Gelen veriyi burda eşitliyoruz.

                if (int_Circle_SendData_Buffer_Cake != old_int_Circle_SendData_Buffer_Cake)   //Fonksiyon Kontrol ediliyorAunı ise girmez.
                {
                    SendData_Buffer = String_Circle_Buffer_Cake;
                    SendData_Function();
                    old_int_Circle_SendData_Buffer_Cake = int_Circle_SendData_Buffer_Cake;          //Timer Buffer Koyman gerekip gerekmediğini sor.
                }
            }
        }
        private void circleAnglePicker_Cake_MouseDown_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Cake = true;
        }
        private void circleAnglePicker_Cake_MouseUp_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Cake = false;
        }

        #endregion 
        #endregion

        #region Cookie
        private void btn_FavCookie_ileri_Click(object sender, EventArgs e)
        {
           
            lblCookieDerece.ForeColor = Color.White;
            lblCookieSaat.ForeColor = Color.White;
            tabPage_Flag = 15;
            tabControl1.SelectedIndex = 15;

            SendData_Buffer = "M25?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Cookie.Visible = false;
        }

        private void btn_FavCookie_geri_Click(object sender, EventArgs e)
        {
           
            lblCookieDerece.ForeColor = Color.White;
            lblCookieSaat.ForeColor = Color.White;
            tabPage_Flag = 6;
            tabControl1.SelectedIndex = 6;

            SendData_Buffer = "M4?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Cookie.Visible = false;
        }
        private void lblCookieDerece_Click_1(object sender, EventArgs e)
        {
            
            tabPage_Flag = 14;
            lblCookieDerece.ForeColor = Color.Red;
            lblCookieSaat.ForeColor = Color.White;

            SendData_Buffer = "M41?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Cookie.Visible = true;
        }
        private void lblCookieSaat_Click_1(object sender, EventArgs e)
        {
           
            tabPage_Flag = 14;
            lblCookieDerece.ForeColor = Color.White;
            lblCookieSaat.ForeColor = Color.Red;

            SendData_Buffer = "M42?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Cookie.Visible = true;
        }

        #region Circle Angle
        private void circleAnglePicker_Cookie_ValueChanged(object sender, EventArgs e)
        {
            Circle_Angle_Picker_Buffer = circleAnglePicker_Cookie.Value;       //Value bir değişkene aktarılıyor.
            CircleAnglePicker_Functions();                                      //Değişken fonksiyonda işleniyor ve değerler ayarlanıyor.
            String_Circle_Buffer_Cookie = String_Circle_Angle_Buffer;         //Fonksiyondaki değer Settings Değişkenine aktarılıyor ve Gönderime hazır hale geliyor.

            if (Circle_Angle_Veri_Flag_Cookie == true)            //Mouseyi bırakır bırakmaz mouseup eventinde false geliyo veri göndermiyz.
            {
                int_Circle_SendData_Buffer_Cookie = CircleAnglePickerBufferVeri;         //Gelen veriyi burda eşitliyoruz.

                if (int_Circle_SendData_Buffer_Cookie != old_int_Circle_SendData_Buffer_Cookie)   //Fonksiyon Kontrol ediliyorAunı ise girmez.
                {
                    SendData_Buffer = String_Circle_Buffer_Cookie;
                    SendData_Function();
                    old_int_Circle_SendData_Buffer_Cookie = int_Circle_SendData_Buffer_Cookie;          //Timer Buffer Koyman gerekip gerekmediğini sor.
                }
            }
        }
        private void circleAnglePicker_Cookie_MouseDown(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Cookie = true;
        }

        private void circleAnglePicker_Cookie_MouseUp(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Cookie = false;
        }
        #endregion
        #endregion

        #region Pie
        private void btn_FavPie_ileri_Click_1(object sender, EventArgs e)
        {
            
            lblPieDerece.ForeColor = Color.White;
            lblPieSaat.ForeColor = Color.White;
            tabPage_Flag = 16;
            tabControl1.SelectedIndex = 16;

            SendData_Buffer = "M26?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Pie.Visible = false;
        }
        private void btn_FavPie_geri_Click_1(object sender, EventArgs e)
        {
           
            lblPieDerece.ForeColor = Color.White;
            lblPieSaat.ForeColor = Color.White;
            tabPage_Flag = 6;
            tabControl1.SelectedIndex = 6;

            SendData_Buffer = "M4?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Pie.Visible = false;
        }
        private void lblPieDerece_Click(object sender, EventArgs e)
        {
            
            tabPage_Flag = 15;
            lblPieDerece.ForeColor = Color.Red;
            lblPieSaat.ForeColor = Color.White;

            SendData_Buffer = "M43?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Pie.Visible = true;
        }
        private void lblPieSaat_Click(object sender, EventArgs e)
        {
          
            tabPage_Flag = 15;
            lblPieDerece.ForeColor = Color.White;
            lblPieSaat.ForeColor = Color.Red;

            SendData_Buffer = "M44?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;
            circleAnglePicker_Pie.Visible = true;
        }

        #region Circle Angle
        private void circleAnglePicker_Pie_ValueChanged_1(object sender, EventArgs e)
        {
            Circle_Angle_Picker_Buffer = circleAnglePicker_Pie.Value;       //Value bir değişkene aktarılıyor.
            CircleAnglePicker_Functions();                                      //Değişken fonksiyonda işleniyor ve değerler ayarlanıyor.
            String_Circle_Buffer_Pie = String_Circle_Angle_Buffer;         //Fonksiyondaki değer Settings Değişkenine aktarılıyor ve Gönderime hazır hale geliyor.

            if (Circle_Angle_Veri_Flag_Pie == true)            //Mouseyi bırakır bırakmaz mouseup eventinde false geliyo veri göndermiyz.
            {
                int_Circle_SendData_Buffer_Pie = CircleAnglePickerBufferVeri;         //Gelen veriyi burda eşitliyoruz.

                if (int_Circle_SendData_Buffer_Pie != old_int_Circle_SendData_Buffer_Pie)   //Fonksiyon Kontrol ediliyorAunı ise girmez.
                {
                    SendData_Buffer = String_Circle_Buffer_Pie;
                    SendData_Function();
                    old_int_Circle_SendData_Buffer_Pie = int_Circle_SendData_Buffer_Pie;          //Timer Buffer Koyman gerekip gerekmediğini sor.
                }
            }
        }

        private void circleAnglePicker_Pie_MouseDown_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Pie = true;

        }

        private void circleAnglePicker_Pie_MouseUp_1(object sender, MouseEventArgs e)
        {
           
            Circle_Angle_Veri_Flag_Pie = false;
        }
        #endregion 
        #endregion

        #region Bread
        private void btn_FavBread_ileri_Click_1(object sender, EventArgs e)
        {
            
            lblBreadDerece.ForeColor = Color.White;
            lblBreadDakika.ForeColor = Color.White;
            tabPage_Flag = 7;
            tabControl1.SelectedIndex = 7;

            SendData_Buffer = "M17?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Bread.Visible = false;
        }
        private void btn_FavBread_geri_Click_1(object sender, EventArgs e)
        {
            
            lblBreadDerece.ForeColor = Color.White;
            lblBreadDakika.ForeColor = Color.White;
            tabPage_Flag = 6;
            tabControl1.SelectedIndex = 6;

            SendData_Buffer = "M4?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Bread.Visible = false;
        }
        private void lblBreadDerece_Click(object sender, EventArgs e)
        {
            
            tabPage_Flag = 16;
            lblBreadDerece.ForeColor = Color.Red;
            lblBreadDakika.ForeColor = Color.White;

            SendData_Buffer = "M45?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Bread.Visible = true;
        }
        private void lblBreadDakika_Click(object sender, EventArgs e)
        {
            
            tabPage_Flag = 16;
            lblBreadDerece.ForeColor = Color.White;
            lblBreadDakika.ForeColor = Color.Red;

            SendData_Buffer = "M46?";                //M2 DEĞERİNİ GÖNDERMEK İÇİN BUFFERE M2? YÜKLÜYORUZ.
            SendData_Function();
            Timer_buffer = true;

            circleAnglePicker_Bread.Visible = true;
        }

        #region Circle Angle
        private void circleAnglePicker_Bread_ValueChanged_1(object sender, EventArgs e)
        {
            Circle_Angle_Picker_Buffer = circleAnglePicker_Bread.Value;       //Value bir değişkene aktarılıyor.
            CircleAnglePicker_Functions();                                      //Değişken fonksiyonda işleniyor ve değerler ayarlanıyor.
            String_Circle_Buffer_Bread = String_Circle_Angle_Buffer;         //Fonksiyondaki değer Settings Değişkenine aktarılıyor ve Gönderime hazır hale geliyor.

            if (Circle_Angle_Veri_Flag_Bread == true)            //Mouseyi bırakır bırakmaz mouseup eventinde false geliyo veri göndermiyz.
            {
                int_Circle_SendData_Buffer_Bread = CircleAnglePickerBufferVeri;         //Gelen veriyi burda eşitliyoruz.

                if (int_Circle_SendData_Buffer_Bread != old_int_Circle_SendData_Buffer_Bread)   //Fonksiyon Kontrol ediliyorAunı ise girmez.
                {
                    SendData_Buffer = String_Circle_Buffer_Bread;
                    SendData_Function();
                    old_int_Circle_SendData_Buffer_Bread = int_Circle_SendData_Buffer_Bread;          //Timer Buffer Koyman gerekip gerekmediğini sor.
                }
            }
        }
        private void circleAnglePicker_Bread_MouseDown_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Bread = true;
        }
        private void circleAnglePicker_Bread_MouseUp_1(object sender, MouseEventArgs e)
        {
            
            Circle_Angle_Veri_Flag_Bread = false;
        }
        #endregion
        #endregion

        #endregion

        #region Form Kapatma Olayları
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BLE_Disconnect();
            th1.Abort();
            
            //Application.Exit();
        }

        #endregion

        
    }
}
