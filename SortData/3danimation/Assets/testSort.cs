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

   // List<Mc2Record> animRecords = new List<Mc2Record>();
    List<List<Mc2Record>> recordsList = new List<List<Mc2Record>>(); 
    int frame = 0;
    public GameObject[] siteobjects = new GameObject [10];// boonsriObject,kohsoomObject;
    List<string> siteNames = new List<string>();
    List<string> measureNames = new List<string>();
    DateTime startDate = new DateTime(1998, 1, 1); //1/1/98
    DateTime endDate = new DateTime(2016, 12, 31); //31/12/16
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
        // prepareAnimateBoonsriMeasure("Water temperature");
        //  List<Mc2Record> tmp = new List<Mc2Record>();
        //   recordsList.Add(tmp);
        //recordsList.Add(new List<Mc2Record>());
        //getListForLocationForMeasure(out recordsList[0], "Boonsri", "Water temperature");
        string measure = "Water temperature";
        List<Mc2Record> tmp1 = new List<Mc2Record>();
        getListForLocationForMeasure( tmp1, "Boonsri", measure );
        tmp1=quantiseListByDate(tmp1, "month");
        recordsList.Add(tmp1);
        tmp1 = new List<Mc2Record>();
        getListForLocationForMeasure( tmp1, "Kohsoom", measure);
        tmp1 = quantiseListByDate(tmp1, "month");
        recordsList.Add(tmp1);
        int k = 10;
    }


    // Update is called once per frame
    int timeSLow = 0;
    int timeSLowLimit = 10;
    void Update () {
        if (timeSLow == timeSLowLimit)
        {
            animateBoonsriWatertemp();
            string dat = recordsList[0][frame].date.ToShortDateString();
            transform.GetChild(0).GetComponent<TextMesh>().text = dat;
            timeSLow = 0;
        }
        else
        timeSLow++;
    }
    Vector3 tmpVec;

    List<Mc2Record> quantiseListByDate(List<Mc2Record> result1,string frequency)
    {

      //  result1 = new List<Mc2Record>();
        List<Mc2Record> result2 = new List<Mc2Record>();
        if (frequency == "month")
        {
            for (int i = 1998; i < 2017; i++)
            {
                for (int j = 1; j < 13; j++)
                {
                   
                    Mc2Record tmp = new Mc2Record();
                    tmp.date = new DateTime(i, j, 1);
                    tmp.value=aggregateListValues(i, j, result1);
                    tmp.location = result1[0].location;
                    tmp.measure = result1[0].measure;
                    result2.Add(tmp);
                }
            }
        }
        return result2;
    }
    public float aggregateListValues(int i, int j, List<Mc2Record> list)
    {
       // float result = 0;
        float max = 0;
     //   float min = 1000000.0;
        List<Mc2Record> result1 = new List<Mc2Record>();
        IEnumerable<Mc2Record> monthRecordsQuery =
              from record in list
              where (record.date.Year == i) && (record.date.Month == j)
              select record;
        foreach (Mc2Record r in monthRecordsQuery)
        {
            result1.Add(r);
            if (r.value > max) max = r.value;
            //  Debug.Log(r.location.ToString()+r.measure.ToString());
        }      
        return max; 
    }

    void animateBoonsriWatertemp()
    {
        int index1 = 0;
        tmpVec = new Vector3(recordsList[index1][frame].value, recordsList[index1][frame].value, recordsList[index1][frame].value);
        siteobjects[index1].transform.localScale= tmpVec;
        index1 = 1;
        tmpVec = new Vector3(recordsList[index1][frame].value, recordsList[index1][frame].value, recordsList[index1][frame].value);
        siteobjects[index1].transform.localScale = tmpVec;
        frame++;
      //  Debug.Log(frame);
        if (frame >= recordsList[1].Count) frame = 0;


    }
    //void prepareAnimateBoonsriMeasure(string str)
    //{
      
    //   //var filteredRecords = records.Where(p.location => location));
   
    //    IEnumerable<Mc2Record> BoonsriQuery =
    //        from record in records
    //        where (record.location=="Boonsri")&&(record.measure==str)
    //        select record;
    //    foreach (Mc2Record r in BoonsriQuery)
    //    {
    //        animRecords.Add(r);
    //                 //  Debug.Log(r.location.ToString()+r.measure.ToString());

    //    }

    //}
    public void getListForLocationForMeasure( List<Mc2Record> result1, string location, string measure)
    {
        //  List<Mc2Record> result1 = new List<Mc2Record>();
        //  List<Mc2Record> result = new List<Mc2Record>;
     //   result1 = new List<Mc2Record>();
        IEnumerable <Mc2Record> LocationMeasureQuery =
              from record in records
              where (record.location == location) && (record.measure == measure)
              select record;
        foreach (Mc2Record r in LocationMeasureQuery)
        {
            result1.Add(r);
            //  Debug.Log(r.location.ToString()+r.measure.ToString());
        }

       // return result1;
    }
    public List<Mc2Record> getListForLocationForMeasure1(string location, string measure)
    {
        List<Mc2Record> result1 = new List<Mc2Record>();
        //  List<Mc2Record> result = new List<Mc2Record>;

        IEnumerable<Mc2Record> LocationMeasureQuery =
              from record in records
              where (record.location == location) && (record.measure == measure)
              select record;
        foreach (Mc2Record r in LocationMeasureQuery)
        {
            result1.Add(r);
            //  Debug.Log(r.location.ToString()+r.measure.ToString());
        }

        return result1;
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
