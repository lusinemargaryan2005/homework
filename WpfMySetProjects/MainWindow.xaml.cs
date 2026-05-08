using System.Windows;
using System.Windows.Controls;
namespace WpfMySetProjects;

public partial class MainWindow : Window
{
    MySet<Student> _men = new MySet<Student>();
    MySet<Student> _women = new MySet<Student>();

    MySet<Student> _reading = new MySet<Student>();
    MySet<Student> _writing = new MySet<Student>();
    MySet<Student> _arithmetic = new MySet<Student>();

    Dictionary<string, MySet<Student>> allSets = new Dictionary<string, MySet<Student>>();

    public MainWindow()
    {
        Student ara = new Student(1, "ara", Gender.Male);
        Student robert = new Student(2, "robert", Gender.Male);
        Student davit = new Student(3, "davit", Gender.Male);
        Student mark = new Student(4, "mark", Gender.Male);
        Student othermark = new Student(5, "othermark", Gender.Male);
        _men.AddRange(new Student[] { ara, robert, davit, mark, othermark });

        Student eva = new Student(1, "eva", Gender.Female);
        Student lilit = new Student(2, "lilit", Gender.Female);
        Student shushi = new Student(3, "shushi", Gender.Female);
        _women.AddRange(new Student[] { eva, lilit, shushi });

        _reading.AddRange(new Student[] { ara, mark, shushi });
        _writing.AddRange(new Student[] { davit, lilit });
        _arithmetic.AddRange(new Student[] { eva, robert });

        allSets.Add("Men", _men);
        allSets.Add("Women", _women);
        allSets.Add("Reading", _reading);
        allSets.Add("Writing", _writing);
        allSets.Add("Arithmetic", _arithmetic);

        InitializeComponent();
    }

    private void Window_loaded(object sender, RoutedEventArgs e)
    {
        foreach (string name in allSets.Keys)
        {
            leftSet.Items.Add(name);
            rightSet.Items.Add(name);
        }

        operation.Items.Add("UNION");
        operation.Items.Add("INTERSECTION");
        operation.Items.Add("DIFFERENCE");
        operation.Items.Add("SYMMETRIC");
    }

    private void leftSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        leftMembers.Items.Clear();
        if (e.AddedItems.Count > 0)
        {
            DisplaySetData(GetSetByName(e.AddedItems[0].ToString()), leftMembers);
        }
    }

    private void rightSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        rightMembers.Items.Clear();
        if (e.AddedItems.Count > 0)
        {
            DisplaySetData(GetSetByName(e.AddedItems[0].ToString()), rightMembers);
        }
    }

    MySet<Student> GetSetByName(string name)
    {
        return allSets[name];
    }

    void DisplaySetData(MySet<Student> set, ListBox list)
    {
        list.Items.Clear();
        foreach (Student s in set.OrderBy(student => student.StudentId))
            list.Items.Add(string.Format("{0}: {1}", s.StudentId, s.Name));
    }

    private void evaluateButton_Click(object sender, RoutedEventArgs e)
    {
        resultSet.Items.Clear();
        if (operation.SelectedItem != null)
        {
            MySet<Student> results = UpdateResultSet(
                GetSetByName(leftSet.SelectedItem.ToString()),
                GetSetByName(rightSet.SelectedItem.ToString()),
                operation.SelectedItem.ToString()
            );
            DisplaySetData(results, resultSet);
        }
    }

    private MySet<Student> UpdateResultSet(MySet<Student> left, MySet<Student> right, string op)
    {
        switch (op)
        {
            case "UNION":
                return left.Union(right);
            case "INTERSECTION":
                return left.Intersection(right);
            case "DIFFERENCE":
                return left.Difference(right);
            case "SYMMETRIC":
                return left.SymmetricDifference(right);
            default:
                MySet<Student> resultSet = new MySet<Student>();
                resultSet.Add(new Student(-1, "ERROR", Gender.Unknown));
                return resultSet;
        }
    }
}