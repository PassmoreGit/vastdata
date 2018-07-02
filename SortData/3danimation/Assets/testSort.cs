using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class testSort : MonoBehaviour {
    int counter = 0;
    string line;
    string[] row;
    List<Mc2Record> records = new List<Mc2Record>();

    List<Mc2Record> animRecords = new List<Mc2Record>();
    int frame = 0;
    public GameObject glyph;
   
 // this reads in serialised data
     void Start()
    {
        try
        {
            using (Stream stream = File.Open("data.bin", FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();

                 records = (List<Mc2Record>)bin.Deserialize(stream);
            }
        }
        catch (IOException)
        {
            int y = 222;
        }
        // Debug.Log("There were  lines." + counter);
        prepareAnimateBoonsriMeasure("Water temperature");
    }
 
	
	// Update is called once per frame
 
	void Update () {
        animateBoonsriWatertemp();
        string dat = animRecords[frame].date.ToShortDateString();
        transform.GetChild(0).GetComponent<TextMesh>().text = dat;
    }

    void animateBoonsriWatertemp()
    { Vector3 tmp = new Vector3(animRecords[frame].value, animRecords[frame].value, animRecords[frame].value);
        glyph.transform.localScale=tmp;
        frame++;
        Debug.Log(frame);
        if (frame >= animRecords.Count) frame = 0;


    }
    void prepareAnimateBoonsriMeasure(string str)
    {
      
       //var filteredRecords = records.Where(p.location => location));
       int t=55;
        IEnumerable<Mc2Record> BoonsriQuery =
            from record in records
            where (record.location=="Boonsri")&&(record.measure==str)
            select record;
        foreach (Mc2Record r in BoonsriQuery)
        {
            animRecords.Add(r);
                     //  Debug.Log(r.location.ToString()+r.measure.ToString());

        }

       
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        var lowNums =
            from n in numbers
            where n < 5
            select n;

        Console.WriteLine("Numbers < 5:");
        foreach (var x in lowNums)
        {
            Console.WriteLine(x);
        }
        int j = 88;
    }

    // St this to Start to read in the csv file and write out the data as a binary list of struct Mc2Record
    void Start1()
    {
        //date range 11-jan-98 - 31-dec-16



        // Read the file and display it line by line.  
        // while   System.IO.StreamReader file = new System.IO.StreamReader(@"e:\test.csv");
        //while   line = file.ReadLine(); // read past header
        int strl1, strl2, strl3;
        string t1, t2, t3;
        // E:\git\vastdata\SortData\3danimation\Assets is location on home machine
        string[] readText = File.ReadAllLines(@"..\..\dataNormalised.csv");
        foreach (string s in readText)
        //while  while ((line = file.ReadLine()) != null)
        {
            if (counter != 0) // skip header
            {
                ;
                //while  row = line.Split(',');
                row = s.Split(',');
                if (row.Length > 5)
                {
                    if (row.Length == 6)
                    {
                        strl1 = row[4].Length;
                        t1 = row[4].Substring(1, strl1 - 1) + ",";
                        strl2 = row[5].Length;
                        t2 = row[5].Substring(0, strl2 - 1);
                        row[4] = t1 + t2;

                    }
                    if (row.Length == 7)
                    {
                        t2 = "";
                        strl1 = row[4].Length;
                        t1 = row[4].Substring(1, strl1 - 1) + ",";
                        strl2 = row[5].Length;
                        if (strl2 == 1) t2 = row[5] + ",";
                        // t2 = row[5].Substring(0, strl2 - 2);
                        strl3 = row[6].Length;
                        t3 = row[6].Substring(0, strl3 - 1);
                        row[4] = t1 + t2 + t3;
                    }
                    if (row.Length == 8)
                    {
                        row[4] = "Indeno(1,2,3-c,d)pyrene";
                    }
                    if (row.Length == 9)
                    {
                        int h2 = 99;
                    }
                }
                records.Add(new Mc2Record(row[0], row[1], row[2], row[3], row[4]));
                if (counter % 10000 == 0) Debug.Log(counter);

            }
            counter++;
        }

        //  file.Close();
        Debug.Log("There were  lines." + counter);
        try
        {
            using (Stream stream = File.Open("data.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, records);
            }
        }
        catch (IOException)
        {
        }
        int g = 33;

    }
}

[Serializable()]
public struct Mc2Record 
{

   public int id;
   public float value;
   public string location;
   public  DateTime date;
   public  string measure;

    public Mc2Record(string idstr, string valuestr, string locationstr,string datestr, string measurestr)
    {
        id = Convert.ToInt32(idstr);
        value = Convert.ToSingle(valuestr);
        location = locationstr;
        date = Convert.ToDateTime(datestr);
        measure = measurestr;
    }
}
