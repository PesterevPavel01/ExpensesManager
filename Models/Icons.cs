using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ExpensesManager.Models
{
    public class Icons
    {
        private string _baseFolder;
        public BitmapImage Ok { get; set; }
        public BitmapImage Edit { get; set; }
        
        public BitmapImage load;

        public BitmapImage loadSelected;

        public BitmapImage documentSetts;

        public BitmapImage documentSettsSelected;
        public BitmapImage navbarOpen { get; set; }
        public BitmapImage navbarOpenSelected { get; set; }
        public BitmapImage navbarClose { get; set; }
        public BitmapImage navbarCloseSelected { get; set; }
        public BitmapImage closeBlue { get; set; }
        public BitmapImage filtrButton { get; set; }
        public BitmapImage filtrButtonSelected { get; set; }
        public BitmapImage document { get; set; }
        public BitmapImage documentSelected { get; set; }
        public BitmapImage search { get; set; }
        public BitmapImage searchSelected { get; set; }
        public BitmapImage searchBlue { get; set; }
        public BitmapImage searchRed { get; set; }
        public BitmapImage download { get; set; }
        public BitmapImage downloadSelected { get; set; }
        public BitmapImage settings { get; set; }
        public BitmapImage settingsSelected { get; set; }
        public BitmapImage addItemToList { get; set; }
        public BitmapImage addItemToListSelected { get; set; }
        public BitmapImage update { get; set; }
        public BitmapImage updateSelected { get; set; }
        public BitmapImage ok { get; set; }
        public BitmapImage okSelected { get; set; }

        public Icons()
        {
            _baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            string[] path = _baseFolder.Split('\\');
            string resourcesPath = string.Empty;
            foreach (string item in path) 
            {
                if (item == "bin")
                {
                    resourcesPath += item;
                    break;
                }
                else
                {
                    resourcesPath += item;
                }
                resourcesPath += "\\";
            }

            _baseFolder = resourcesPath+ "\\Resources\\icons";

            Ok = new BitmapImage();
            Ok.BeginInit();
            Ok.UriSource = new Uri(_baseFolder + "\\Ok.png");
            Ok.EndInit();

            Edit = new BitmapImage();
            Edit.BeginInit();
            Edit.UriSource = new Uri(_baseFolder + "\\Edit.png");
            Edit.EndInit();

            load = new BitmapImage();
            load.BeginInit();
            load.UriSource = new Uri(_baseFolder + "\\load.png");
            load.EndInit();

            loadSelected = new BitmapImage();
            loadSelected.BeginInit();
            loadSelected.UriSource = new Uri(_baseFolder + "\\loadSelected.png");
            loadSelected.EndInit();

            documentSelected = new BitmapImage();
            documentSelected.BeginInit();
            documentSelected.UriSource = new Uri(_baseFolder + "\\DocumentSelected.png");
            documentSelected.EndInit();

            document = new BitmapImage();
            document.BeginInit();
            document.UriSource = new Uri(_baseFolder + "\\Document.png");
            document.EndInit();

            filtrButtonSelected = new BitmapImage();
            filtrButtonSelected.BeginInit();
            filtrButtonSelected.UriSource = new Uri(_baseFolder + "\\FilterSelected.png");
            filtrButtonSelected.EndInit();

            filtrButton = new BitmapImage();
            filtrButton.BeginInit();
            filtrButton.UriSource = new Uri(_baseFolder + "\\Filter.png");
            filtrButton.EndInit();

            closeBlue = new BitmapImage();
            closeBlue.BeginInit();
            closeBlue.UriSource = new Uri(_baseFolder + "\\closeBlue.png");
            closeBlue.EndInit();

            settings = new BitmapImage();
            settings.BeginInit();
            settings.UriSource = new Uri(_baseFolder + "\\settings.png");
            settings.EndInit();

            settingsSelected = new BitmapImage();
            settingsSelected.BeginInit();
            settingsSelected.UriSource = new Uri(_baseFolder + "\\settingsSelected.png");
            settingsSelected.EndInit();

            downloadSelected = new BitmapImage();
            downloadSelected.BeginInit();
            downloadSelected.UriSource = new Uri(_baseFolder + "\\downloadSelected.png");
            downloadSelected.EndInit();

            download = new BitmapImage();
            download.BeginInit();
            download.UriSource = new Uri(_baseFolder + "\\download.png");
            download.EndInit();

            searchRed = new BitmapImage();
            searchRed.BeginInit();
            searchRed.UriSource = new Uri(_baseFolder + "\\searchRed.png");
            searchRed.EndInit();

            searchBlue = new BitmapImage();
            searchBlue.BeginInit();
            searchBlue.UriSource = new Uri(_baseFolder+"\\searchBlue.png");
            searchBlue.EndInit();

            searchSelected = new BitmapImage();
            searchSelected.BeginInit();
            searchSelected.UriSource = new Uri(_baseFolder + "\\SelectedSearch.png");
            searchSelected.EndInit();

            search = new BitmapImage();
            search.BeginInit();
            search.UriSource = new Uri(_baseFolder + "\\Search.png");
            search.EndInit();

            navbarOpen = new BitmapImage();
            navbarOpen.BeginInit();
            navbarOpen.UriSource = new Uri(_baseFolder + "\\Folder.png");
            navbarOpen.EndInit();

            navbarOpenSelected = new BitmapImage();
            navbarOpenSelected.BeginInit();
            navbarOpenSelected.UriSource = new Uri(_baseFolder + "\\FolderSelected.png");
            navbarOpenSelected.EndInit();

            navbarClose = new BitmapImage();
            navbarClose.BeginInit();
            navbarClose.UriSource = new Uri(_baseFolder + "\\Close.png");
            navbarClose.EndInit();

            navbarCloseSelected = new BitmapImage();
            navbarCloseSelected.BeginInit();
            navbarCloseSelected.UriSource = new Uri(_baseFolder + "\\CloseSelected.png");
            navbarCloseSelected.EndInit();

            documentSetts = new BitmapImage();
            documentSetts.BeginInit();
            documentSetts.UriSource = new Uri(_baseFolder + "\\docSetts.png");
            documentSetts.EndInit();

            documentSettsSelected = new BitmapImage();
            documentSettsSelected.BeginInit();
            documentSettsSelected.UriSource = new Uri(_baseFolder + "\\docSettsSelect.png");
            documentSettsSelected.EndInit();

            addItemToList = new BitmapImage();
            addItemToList.BeginInit();
            addItemToList.UriSource = new Uri(_baseFolder + "\\addItemIcon.png");
            addItemToList.EndInit();

            addItemToListSelected = new BitmapImage();
            addItemToListSelected.BeginInit();
            addItemToListSelected.UriSource = new Uri(_baseFolder + "\\addItemSelectIcon.png");
            addItemToListSelected.EndInit();

            update = new BitmapImage();
            update.BeginInit();
            update.UriSource = new Uri(_baseFolder + "\\UpdateIcon.png");
            update.EndInit();

            updateSelected = new BitmapImage();
            updateSelected.BeginInit();
            updateSelected.UriSource = new Uri(_baseFolder + "\\UpdateSelectIcon.png");
            updateSelected.EndInit();

            ok = new BitmapImage();
            ok.BeginInit();
            ok.UriSource = new Uri(_baseFolder + "\\okIcon.png");
            ok.EndInit();

            okSelected = new BitmapImage();
            okSelected.BeginInit();
            okSelected.UriSource = new Uri(_baseFolder + "\\okSelectIcon.png");
            okSelected.EndInit();
        }

    }
}
