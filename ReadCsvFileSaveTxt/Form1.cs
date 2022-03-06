using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ReadCsvFileSaveTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        #region PUBLİC OLARAK UYGULAMADA KULLANACAĞIMI DEĞİŞKENLERİ BURADA TANIMLADIK
        //Kullanıcıdan alacağımız klasör, data ve template yollarını tutmak için oluşturduğumuz değişkenler
        string FolderPath, templatePath, filePath, txtTemplate, neededPlaceHolders, dateText = "{TARIH}";
        //Kullanıcı yer tutucuları kendi girmek isterse bunları tutmak için oluşturduğumuz değişken
        string[] givenPlaceHolders;
        DateTime date = DateTime.Now;
        //Eğer kullanıcı kendine özel yer tutucuları girmezse varsayılan olarak bu 4 değer kullanılacak
        string[] defaultPlaceHolders = new string[] { "{FATURANO}", "{AD}", "{SOYAD}", "{TUTAR}" };
        #endregion

        #region DATA DOSYASINI BURAYA TIKLAYARAK YÜKLÜYORUZ
        private void btnFilePath_Click(object sender, EventArgs e)
        {
            //Data yükleyip, formatını kontrol ettiğimiz ve yolunu aldığımız methodu çağırıyoruz
            GetFilePath();
        }
        #endregion

        #region ÇÖZÜMLENECEK KLASÖRÜ BURAYA TIKLAYARAK SEÇİYORUZ
        private void btnRegisterPath_Click(object sender, EventArgs e)
        {
            //Çözümlemenin yapılacağı klasörü seçip, yolunu aldığımız methodu çağırıyoruz
            GetFileFolderPath();
        }
        #endregion

        #region ŞABLON OLARAK KULLANACAĞIMIZ DOSYAYI BURAYA TIKLAYARAK YÜKLÜYORUZ
        private void btnTemplateUpload_Click(object sender, EventArgs e)
        {
            //Çözümlemek için kullanılacak şablonu yüklediğimiz, formatını kontrol edip yolunu aldığımız methodu çağırıyoruz
            GetTemplatePath();
        }
        #endregion

        #region YÜKLENEN DOSYALAR VE GİRİLEN DEĞERLERE GÖRE ÇÖZÜMLEME İŞLEMİNİ BURAYA TIKLAYARAK BAŞLATIYORUZ
        private void btnCreateFiles_Click(object sender, EventArgs e)
        {
            //Çözümlemeyi başlatmak için gerekli methodumuzu çağırıyoruz
            CreateTxtFiles();
        }
        #endregion

        #region KLASÖR SEÇİP KONTROLLERİNİ YAPIP YOLUNU DEĞİŞKENE BURADA ATIYORUZ
        private void GetFileFolderPath()
        {
            //Klasör seçmek için kullanılan dialog'u belirtiyoruz
            var SelectFolder = new FolderBrowserDialog();
            DialogResult result = SelectFolder.ShowDialog();
            //Eğer dialogta klasör seçilip onaylanmışsa yada seçilen yol boş değilse işlem yapmak için sorguluyoruz
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(SelectFolder.SelectedPath))
            {
                lblRegisterPath.Text = SelectFolder.SelectedPath + "\\";
                //En yukarıda tanımladığımız klasör yolunu tutmak için kullanacağımız değişkene seçilen klasörün yolunu atıyoruz
                FolderPath = SelectFolder.SelectedPath + "\\";
            }
            //Eğer dialog ekranında seçim yapılmadıysa geriye null değer döndürmek için sorguluyoruz
            if (result == DialogResult.Cancel)
            {
                lblRegisterPath.Text = null;
                FolderPath = null;
            }
        }
        #endregion

        #region ŞABLON OLARAK KULLANACAĞIMIZ DOSYAYI BURADAN YÜKLÜYORUZ
        private void GetTemplatePath()
        {
            //Burada eklediğimiz dialog aracını sadece txt dosyalarını gösterecek ve birden fazla dosya seçilemeyecek şekilde filtreledik
            OpenFileDialog dialog = FileDialogTemplate;
            dialog.Filter = "Text files | *.txt";
            dialog.Multiselect = false;
            dialog.ShowDialog();

            //Eğer şablon dosyası seçildiyse uzantısını öğrenmek için kontrol ediyoruz
            if (dialog.CheckFileExists && dialog.FileName != string.Empty)
            {
                //Yüklenen dosyanın uzantısını burada buluyoruz
                FileInfo getExtension = new FileInfo(dialog.SafeFileName);
                string extension = getExtension.Extension;
                //Uzantısı .txt mi değil mi kontrol ediyoruz. Eğer uzantısı doğru ise değişkene değerini atıyoruz
                if (extension == ".txt")
                {
                    templatePath = Path.GetFullPath(dialog.FileName);
                    lblTemplatePath.Text = templatePath;
                }
                else
                {
                    //Eğer dosya hiç seçilmemişse uyarı vermeyecek. Ama farklı formatta dosya seçilmeye çalışıldıysa aşağıdaki format uyarısını verecek
                    if(!string.IsNullOrEmpty(dialog.FileName))
                    { 
                    MessageBox.Show(".TXT formatında dosya seçiniz", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    templatePath = null;
                    lblTemplatePath.Text = string.Empty;
                    }
                }
            }
        }
        #endregion

        #region ÇÖZÜMLEME YAPACAĞIMIZ DATA DOSYASININ YOLUNU VE KONTROLLERİNİ BURADA YAPIYORUZ
        private void GetFilePath()
        {
            //Data dosyasını yüklemek için tanımladığımı dialog aracını burada sadece .csv dosyaları olacak ve birden fazla dosya seçilemeyecek şekilde filtreledik
            OpenFileDialog dialog = FileDialogCSV;
            dialog.Filter = "Text files | *.csv";
            dialog.Multiselect = false;
            dialog.ShowDialog();
            //Dosyanın seçilip seçilmediğini kontrol ediyoruz
            if (dialog.CheckFileExists && dialog.FileName != string.Empty)
            {
                //Data dosyasının uzantısını işlemlere başlamadan önce hata vermemesi için kontrol ediyoruz
                FileInfo getExtension = new FileInfo(dialog.SafeFileName);
                string extension = getExtension.Extension;

                //Eğer  data dosyasının uzantısı .csv ise işlemlere başlıyoruz
                if (extension == ".csv")
                {
                    //Yüklenen data dosyasının yolunu buluyoruz ve
                    filePath = Path.GetFullPath(dialog.FileName);
                    lblFilePath.Text = filePath;
                }
                else
                {
                    // Farklı formatta dosya yüklenmeye çalışıldı ve program patlamaması için uyarı ekranı çıkarıldı
                    MessageBox.Show("Yanlış formatta kaynak yüklediniz. Lütfen \".CSV\" formatında kaynak seçiniz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    filePath = null;
                    lblFilePath.Text = null;
                }
            }
        }
        #endregion

        #region TÜM GEREKLİ VERİ YOLLARININ GİRİLİP GİRİLMEDİĞİNİ BURADA KONTROL EDİYORUZ (DATA,ŞABLON,KLASÖR SEÇİMLERİ)
        //Geri dönüşümlü bir method oluşturduk. Burada gerekli veri yollarının girilip girilmediğini kontrol ediyoruz. Eğer tüm yollar girilmişse TRUE değeri geri dönecek ve işlemlere başlayabileceğiz. Eksik varsa FALSE değeri geri dönecek ve kullanıcıdan gerekli bilgileri doldurması istenecek
        private bool CheckAllPath(string checkFolder, string checkFile, string checkTemplate)
        {
            //Eğer tüm yollar seçilmediyse toplu bir uyarı için burada sorguluyoruz
            if (checkFolder == null && checkFile == null && checkTemplate == null)
            {
                MessageBox.Show("Lütfen tüm gerekli belgeleri ve kayıt yolunu belirtiniz!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                //Yalnız çözümleme yapılacak klasör yolunun seçilip seçilmediğini kontrol ediyoruz
                if (checkFolder == string.Empty || checkFolder == "" || checkFolder == null)
                {
                    MessageBox.Show("Lütfen dökümanın çözümleneceği klasörü seçiniz!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                }
                //Yalnız çözümleme yapılacak Data yolunun seçilip seçilmediğini kontrol ediyoruz
                else if (checkFile == string.Empty || checkFile == "" || checkFile == null)
                {
                    MessageBox.Show("Lütfen çözümlenecek dökümanı seçiniz!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //Yalnız şablon olarak kullanılacak dosya yolunun seçilip seçilmediğini kontrol ediyoruz
                else if (checkTemplate == string.Empty || checkTemplate == "" || checkTemplate == null)
                {
                    MessageBox.Show("Lütfen dökümanın çözümlenmesini istediğiniz şablonu seçiniz!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            //Eğer tüm yollar seçilmiş ve sorun yoksa işlemlere başlamak için gerekli TRUE değerini veriyoruz
            return true;
        }
        #endregion

        #region KULLANICI YER TUTUCU GİRDİ Mİ YOKSA VARSAYILANLARI MI KULLANMAK İSTİYOR DİYE BURADA KONTROL EDİYORUZ
        private bool GetPlaceHolders(string placeHolders)
        {
            //Kullanıcı yer tutucu olarak kullanmak için giriş yapmış mı diye burada kontrol ediyoruz. Eğer giriş yaptıysa TRUE değer döndürüp kullanıcının girdiği değerleri şablonda aratıp kullanacağız
            if (placeHolders != "" || !string.IsNullOrEmpty(placeHolders))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region GİRİLEN YER TUTUCULARDA TÜRKÇE KARAKTER SORUNU OLMAMASI İÇİN TEXT DEĞERİNE BURADA MÜDAHALE EDİYORUZ
        private void txtPlaceHolders_Leave(object sender, EventArgs e)
        {
            //Eğer girilen text'lerde türkçe karakter varsa diye sorgulamak için ve varsa yerine şunu yaz demek için 2 tane şablon dizisi oluşturduk
            string[] checkSpecialCharacters = new string[] { "Ö", "İ", "Ğ", "Ç", "Ü", "Ş" };
            string[] changeSpecialCharacters = new string[] { "O", "I", "G", "C", "U", "S" };

            //Textboxa girilen değerlerin hepsini öncelikle büyük harfe çeviriyoruz
            txtPlaceHolders.Text = txtPlaceHolders.Text.ToUpper();

            //Döngüyü belirlediğimiz türkçe karakterlerden oluşan şablonun uzunluğu kadar döndürüyoruz
            for (int j = 0; j < checkSpecialCharacters.Length; j++)
            {
                //Yukarıdaki türkçe karakterlerden birisi içeriyor mu diye kontrol ediyoruz
                if (txtPlaceHolders.Text.Contains($"{checkSpecialCharacters[j]}"))
                {
                    //Eğer text'in içerisinde türkçe karakter varsa onu diğer şablon dizisindeki karşıtı ile değiştir diyoruz
                    txtPlaceHolders.Text = Regex.Replace(txtPlaceHolders.Text, $"{checkSpecialCharacters[j]}", changeSpecialCharacters[j]);
                }
            }
            //Textbox'tan ayrıldığımızda yazı imleci en başta değil de en sonda kaldığımız yerde belirmesi için yazıyoruz
            txtPlaceHolders.SelectionStart = txtPlaceHolders.Text.Length;
        }
        #endregion

        #region TÜM KONTROLLERİN SONUNDA SORUN YOKSA ÇÖZÜMLEME İŞLEMİNİN YAPILACAĞI İŞLEMLERİ BURADA TANIMLADIK
        private void CreateTxtFiles()
        {
            //öncelikle Data,Şablon ve Klasör yolları verilmiş mi diye kontrol ediyoruz
            if (CheckAllPath(FolderPath, filePath, templatePath))
            {
                //Yüklenen data dosyasındaki tüm satırları okuyup belirlediğimiz değişkene atıyoruz
                var rowsUploadedDocument = File.ReadAllLines(filePath);
                //Tüm satırlardaki noktalı virgül ile ayrılan kayıtları çözümleyip, indexliyoruz
                var uploadedDocument = from row in rowsUploadedDocument
                                       select row.Split(';').ToArray();
                //Kullanıcı kendi girdiği yer tutucuları mı kullanmak istiyor varsayılan olanları mı burada kontrol ediyoruz. Herhangi bir yer tutucu girmiş mi diye kontrol ettiğimiz methodu çağırıyoruz
                if (GetPlaceHolders(txtPlaceHolders.Text))
                {
                    //Eğer yer tutucu girdiyse en üstte tanımladığımı kullanıcı tarafından girilen yer tutucular değişkenimize ayrıştırma yapmak için atıyoruz
                    givenPlaceHolders = new string[] {
                txtPlaceHolders.Text
                };
                    //Burada kullanıcının girdiği yer tutucuları ayırıp, indexliyoruz
                    var rowsGivenPlaceHolders = from gph in givenPlaceHolders
                                                select gph.ToUpper().Split(';').ToArray();

                    //Kullanıcının yüklediği Data dosyasını satır satır okumak için listeyi döndürüyoruz
                    foreach (var findValues in uploadedDocument)
                    {
                        //Her seferinde şablonu sıfırlayıp, yeni değerleri üzerine yazabilmemiz için burada tanımlıyoruz
                        txtTemplate = File.ReadAllText(templatePath);

                        //Kullanıcının girdiği yer tutucuları teker teker şablonun içerisinde var mı diye sorgulamak için listesinde dönüyoruz
                        foreach (var givenValues in rowsGivenPlaceHolders)
                        {
                            //Eğer kullanıcının girdiği yer tutucuların sayısı yüklediği datadaki çeşitlilikten fazlaysa hata oluşmaması için uyarı verdiriyoruz
                            if (findValues.Length > givenValues.Length)
                            {
                                lblNeededPlaceholders.Text = null;
                                neededPlaceHolders = $"{findValues.Length - givenValues.Length} yer tutucu daha gerekli!";
                                lblNeededPlaceholders.Text = neededPlaceHolders;
                                MessageBox.Show("Girmiş olduğunuz yer tutucu sayısı, yüklemiş olduğunuz dökümanda bulunan alan sayısından azdır. Lütfen tüm alan bilgilerini giriniz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            //Eğer kullanıcının girdiği yer tutucuların sayısı yüklediği datadaki çeşitlilikten azsa hata oluşmaması için uyarı verdiriyoruz
                            else if (findValues.Length < givenValues.Length)
                            {
                                lblNeededPlaceholders.Text = null;
                                neededPlaceHolders = $"{givenValues.Length - findValues.Length} yer tutucu fazla yazıldı!";
                                lblNeededPlaceholders.Text = neededPlaceHolders;
                                MessageBox.Show("Girmiş olduğunuz yer tutucu sayısı, yüklemiş olduğunuz dökümanda bulunan alan sayısından fazladır. Lütfen gerekli alan bilgilerini giriniz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            lblNeededPlaceholders.Text = null;
                            //Eğer yer tutucularda da sorun yoksa girilen yer tutucuların yüklenen şablonun içerisindeki yerlerini burada bulacağız
                            for (int i = 0; i < givenValues.Length; i++)
                            {
                                //Yüklenen şablonun içerisinde kullanıcının girdiği yer tutucu var mı diye bakıyoruz
                                if (txtTemplate.Contains("{" + givenValues[i].ToUpper() + "}") || txtTemplate.Contains("{" + givenValues[i].ToLower() + "}"))
                                {
                                    //Eğer yer tutucu varsa onu kaldırıp, yerine data.csv dosyasındaki ilgili alanın değerlerini yerleştiriyoruz
                                    txtTemplate = Regex.Replace(txtTemplate, "{" + givenValues[i] + "}", findValues[i]);
                                    //Tarih alanı varsayılan olarak olacağı için onu yukarıda tanımladığımız dateText="{TARIH}" stringinden sorguluyoruz
                                    if (txtTemplate.Contains(dateText.ToLower()) || txtTemplate.Contains(dateText.ToUpper()))
                                    {
                                        txtTemplate = Regex.Replace(txtTemplate, $"{dateText}", date.ToShortDateString());
                                    }
                                }
                                //Aşağıda belirttiğimiz yolda ve .csv içerisinden aldığımız veri adıyla .txt dosyası oluşturuyoruz
                                FileStream createTxt = new FileStream($"{FolderPath}{findValues[0]}.txt", FileMode.Create, FileAccess.Write);
                                //Oluşturduğumuz dosyayı hedef gösterip, içerisine yazacağımız dosyayı belirtmiş oluyoruz
                                StreamWriter writeTxt = new StreamWriter(createTxt);
                                //Dosyanın içerisine yazmaya sondan başlayıp, başa doğru yazması için yazım akışını değiştiriyoruz
                                writeTxt.BaseStream.Seek(0, SeekOrigin.End);
                                //Oluşturduğumuz dosyanın içerisinde yukarıda modelden alıp düzenlediğimiz yeni metinleri yazdırıyoruz
                                writeTxt.Write(txtTemplate);
                                //Arabellekte bulunan tüm verileri dosyaya yazmasını sağlarız
                                writeTxt.Flush();
                                //Dosya hazırlandı ve kapatıldı
                                writeTxt.Close();
                            }
                        }
                    }
                    //Eğer işlemler sorunsuz ilerleyip, çözümleme tamamlandıysa kullanıcıya başarı mesajını gösteriyoruz
                    MessageBox.Show("Döküman çözümlemesi başarı ile tamamlandı. Belirttiğiniz klasör içerisine kaydedilmiştir!","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                //Eğer kullanıcı kendisi yer tutucu girmediyse varsayılan değerler olan (FATURANO;AD;SOYAD;TUTAR) tutucuları ile işlem yaptıracağız
                else
                {
                    //Kullanıcının yüklediği data.csv dosyasını satır satır çözümlemek için içinde dönüyoruz
                    foreach (var findValues in uploadedDocument)
                    {
                        //Her seferinde şablonu sıfırlayıp yer tutucuların bulunabilmesi için burada yazıyoruz
                        txtTemplate = File.ReadAllText(templatePath);
                        //Varsayılan olarak atadığımız yer tutucuların bulunduğu dizinin uzunluğu kadar içinde dönüp her seferinde bilgileri alarak yeni .txt dosyaları oluşturacağız
                        for (int i = 0; i < defaultPlaceHolders.Length; i++)
                        {
                            //Eğer yüklenen şablonun içerisinde varsayılan olarak girdiğimiz yer tutucular varsa onları kaldırıp yerlerine data.csv dosyasındaki ilgili alanları basacağız
                            if (txtTemplate.Contains(defaultPlaceHolders[i].ToUpper()) || txtTemplate.Contains(defaultPlaceHolders[i].ToLower()))
                            {
                                //Eğer yer tutucu bulunduysa onu kaldırıp, yerine data.cvs deki ilgili alanı yazıyoruz
                                txtTemplate = Regex.Replace(txtTemplate, $"{defaultPlaceHolders[i]}", findValues[i]);
                                if (txtTemplate.Contains(dateText.ToLower()) || txtTemplate.Contains(dateText.ToUpper()))
                                {
                                    txtTemplate = Regex.Replace(txtTemplate, $"{dateText}", date.ToShortDateString());
                                }
                            }
                            //Aşağıda belirttiğimiz yolda ve .csv içerisinden aldığımız veri adıyla .txt dosyası oluşturuyoruz
                            FileStream createTxt = new FileStream($"{FolderPath}{findValues[0]}.txt", FileMode.Create, FileAccess.Write);
                            //Oluşturduğumuz dosyayı hedef gösterip, içerisine yazacağımız dosyayı belirtmiş oluyoruz
                            StreamWriter writeTxt = new StreamWriter(createTxt);
                            //Dosyanın içerisine yazmaya sondan başlayıp, başa doğru yazması için yazım akışını değiştiriyoruz
                            writeTxt.BaseStream.Seek(0, SeekOrigin.End);
                            //Oluşturduğumuz dosyanın içerisinde yukarıda modelden alıp düzenlediğimiz yeni metinleri yazdırıyoruz
                            writeTxt.Write(txtTemplate);
                            //Arabellekte bulunan tüm verileri dosyaya yazmasını sağlarız
                            writeTxt.Flush();
                            //Dosya hazırlandı ve kapatıldı
                            writeTxt.Close();
                        }
                    }
                    //Eğer tüm işlemler sorunsuz ilerlediyse ve çözümleme başarıyla bittiyse kullanıcıya bilgisini veriyoruz
                    MessageBox.Show("Döküman çözümlemesi başarı ile tamamlandı. Belirttiğiniz klasör içerisine kaydedilmiştir!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion
    }
}

