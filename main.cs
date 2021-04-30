using System;
using System.Collections;
using System.IO;

public class Agenda {
  private SortedList dic { get; set; }

  public void PrintDic() {
    ICollection c = dic.Keys;
  
    foreach(string str in c) {
      Console.WriteLine(str + " - " + dic[str]);
    }
  }

  public void AbrirArquivo(string arquivo) {
    try {
      var file = new StreamReader(arquivo);
      string line;

      while ((line = file.ReadLine()) != null) {
        string[] entries = line.Split(';');
        string username = entries[0];
        string phoneNumber = entries[1];

        if (!dic.Contains(username)) {
          dic.Add(username, phoneNumber);
        } else {
          dic.Remove(username);
          dic.Add(username, phoneNumber);
        }
      }

      file.Close();
    } catch (IOException e) {
      Console.WriteLine("The file could not be read:");
      Console.WriteLine(e.Message);
    }
  }

  public Agenda() {
    dic = new SortedList();
  }
}

class Program {
  public static void Main() {
    var agenda = new Agenda();
    agenda.AbrirArquivo("text.txt");

    agenda.PrintDic();
  }
}
