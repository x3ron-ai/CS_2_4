using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS_2_4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // моя мечта - c# в саблайме. я согласен через консоль компилить проги, саблайм того стоит
            UpdateTypesList();
            ogo_calendar.SelectedDate = DateTime.Now.Date; // календарь в шоке
        }
        private int GetFreeNoteId() // самый большой кастыль
        {
            List<Note> notes = JsonWorking.Deserializing<List<Note>>("../../../notes.json"); // честно лучше способа открыть файл не нашел да и не искал
            int freeId = 1;
            notes = notes.OrderBy(x => x.id).ToList();
            Note lastNote = notes.LastOrDefault(); // хз как работает этот default 
            if (lastNote != null)
            {
                freeId = lastNote.id + 1;
            }
            else
            {
                freeId = 1;
            }
            return freeId; // уровень эффективности стремится к -5
        }
        private void RefreshWindow()
        {
            typesList.SelectedIndex = -1;
            nameInput.Text = "";
            countInput.Text = "";
        }
        private List<Note> GetTodayNotes(List<Note> notes, out double todaySumm, out double allSumm) // ауты это круто, пока ауты не в твоей команде
        {
            todaySumm = 0;
            allSumm = 0;
            DateTime date = Convert.ToDateTime(ogo_calendar.SelectedDate);
            List<Note> todayNotes = new List<Note>();
            foreach (Note note in notes)
            {
                allSumm += note.count;
                if (note.date.Date == date.Date)
                {
                    todaySumm += note.count;
                    todayNotes.Add(note);
                }
            }
            return todayNotes;
        }
        private void UpdateNotes(Note newNote = null) 
        {
            string notePath = "../../../notes.json"; 
            List<Note> notes = JsonWorking.Deserializing<List<Note>>(notePath);
            double todaySumm; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; // ашалеть круто
            double allSumm;
            if (newNote != null)
            {
                notes.Add(newNote);
                JsonWorking.Serializing(notePath, notes);
            }
            notesContainer.ItemsSource = GetTodayNotes(notes, out todaySumm, out allSumm);
            allSum.Text = $"Общая сумма: {allSumm}"; // если честно случайно назвал textBlock allsum, а переменную allsumm
            todaySum.Text = $"Общая сумма: {todaySumm}";

        }
        private void UpdateTypesList(string newVal = "")
        {
            string typePath = "../../../types.json";
            List<string> types = new List<string>();
            types = JsonWorking.Deserializing<List<string>>(typePath);
            if (newVal != "")
            {
                types.Add(newVal);
                JsonWorking.Serializing(typePath, types);
            }
            typesList.ItemsSource = types;
        }
        private void DeleteData()
        {
            int selectedId = ((Note)notesContainer.SelectedItem).id; // я был приятно удивлен, почему же я не использовал этого раньше? 
            string notePath = "../../../notes.json";
            List<Note> notes = JsonWorking.Deserializing<List<Note>>(notePath);
            List<Note> newNotes = new List<Note>();
            foreach (Note note in notes)
            {
                if (note.id != selectedId)
                {
                    newNotes.Add(note);
                }
            }
            JsonWorking.Serializing(notePath, newNotes);
        }
        private void EditData()
        {
            int selectedId = ((Note)notesContainer.SelectedItem).id;
            string[] values;
            if (typesList.SelectedValue != null)
                values = new string[] { nameInput.Text, countInput.Text, typesList.SelectedValue.ToString() };
            else
                values = new string[] { nameInput.Text, countInput.Text, "" }; // мне впадлу без if'a, на 136 строке описано что будет без него.
            if (values.Contains("") || values.Contains(null))                  // А переписывать без массива этого крутого и сравнивать просто мне лень))0
            {
                MessageBox.Show("Some fields are empty!\nI think u need to fill it!");
            }
            else
            {
                try
                {
                    Note newNote = new Note(selectedId, values[0], values[2], Convert.ToDouble(values[1]), Convert.ToDateTime(ogo_calendar.SelectedDate));
                    DeleteData();         // тут моментами
                    UpdateNotes(newNote); // кастылим чутка
                }                         // ну не искать же мне в массива элемент
                catch (Exception ex)
                {
                    MessageBox.Show($"It's look like u entered invalid data!\n{123} >:("); // раньше вместо 123 был текст ошибки, но мне это все равно не помогало
                }
            }
        }
        private void SaveData()
        {                                                                           // этот трындец обусловлен тем, что мне лень писать нормально
            string[] values = new string[] { nameInput.Text, countInput.Text, (typesList.SelectedValue != null ? typesList.SelectedValue.ToString() : "") /* я был приятно удивлен, почему же я не использовал этого раньше? */ };
            if (values.Contains("") || values.Contains(null))
            {
                MessageBox.Show("Some fields are empty!\nI think u need to fill it!");
            }
            else
            {
                try
                {
                    Note newNote = new Note(GetFreeNoteId(), values[0], values[2].ToString(), Convert.ToDouble(values[1]), Convert.ToDateTime(ogo_calendar.SelectedDate));
                    UpdateNotes(newNote);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"It's look like u entered invalid data!\n{123} >:(");
                }
            }
        }
        private void createDatatype_Click(object sender, RoutedEventArgs e) // самое бесполезное - новые типы добавлять и хранить
        {
            /*
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣄⢘⣒⣀⣀⣀⣀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣽⣿⣛⠛⢛⣿⣿⡿⠟⠂⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⣀⡀⠀⣤⣾⣿⣿⣿⣿⣿⣿⣿⣷⣿⡆⠀
            ⠀⠀⠀⠀⠀⠀⣀⣤⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠀
            ⠀⠀⠀⢀⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀
            ⠀⠀⣠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀
            ⠀⠀⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠜⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⢿⣿⣿⣿⣿⠿⠿⣿⣿⡿⢿⣿⣿⠈⣿⣿⣿⡏⣠⡴⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⣠⣿⣿⣿⡿⢁⣴⣶⣄⠀⠀⠉⠉⠉⠀⢻⣿⡿⢰⣿⡇⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⢿⣿⠟⠋⠀⠈⠛⣿⣿⠀⠀⠀⠀⠀⠀⠸⣿⡇⢸⣿⡇⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⢸⣿⠀⠀⠀⠀⠀⠘⠿⠆⠀⠀⠀⠀⠀⠀⣿⡇⠀⠿⠇⠀⠀⠀⠀⠀
             */
            TypeInput typeInput = new TypeInput();
            typeInput.ShowDialog();
            if (typeInput.isResponse)
            {
                string inputed = typeInput.typedName;
                UpdateTypesList(inputed);
            }
        }
        private void dateUpdated(object sender, EventArgs e)
        {
            UpdateNotes();
            RefreshWindow();
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
            RefreshWindow();
        }

        private void notesContainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (notesContainer.SelectedIndex == -1) { return; }
            Note selectedNote = (Note)notesContainer.SelectedItem;
            nameInput.Text = selectedNote.name;
            countInput.Text = selectedNote.count.ToString();
            typesList.SelectedIndex = -1;
        }
        // тупа две функции хайповые
        private void EditNote_Click(object sender, RoutedEventArgs e)
        {
            EditData();
            RefreshWindow();
        }

        private void RemoveNote_Click(object sender, RoutedEventArgs e)
        {
            DeleteData();
            RefreshWindow();
        }
        // изначально хотел чтобы где-то гифка прыгала на фоне, было бы весело
        // я чето где-то поисправлял, забыл что где исправлял, не стал тестировать, загрузил на гит
    }
}
