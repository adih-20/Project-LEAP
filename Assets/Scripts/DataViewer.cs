using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
//using Microsoft.VisualBasic.FileIO;
using System;

public class DataViewer : MonoBehaviour
{

    public Transform player;

    public Text theText;

    string[][] dataF = new string[][] { };
    // Start is called before the first frame update
    void Start()
    {
        string filePath = @"DATA_CENTRAL2.csv";
        StreamReader sr = new StreamReader(filePath);
        var lines = new List<string[]>();
        int Row = 0;
        while (!sr.EndOfStream)
        {
            string[] Line = (sr.ReadLine().Split(','));
            lines.Add(Line);
            Row++;
            //Debug.Log(Row);
        }

        dataF = lines.ToArray();


    }

    // Update is called once per frame
    void Update()
    {
        double curr_x = player.position.x;
        double curr_z = player.position.z;
        double lat = 0.0;
        double lon = 0.0;
        double height = 0.0;
        double slope = 0.0;
        double elevation = 0.0;
        double azimuth = 0.0;
        for (int row = 0; row < dataF.GetLength(0); row++)
        {
            if ( (Math.Round(curr_x, 3) == Math.Round(Double.Parse(dataF[row][3]), 3)) && (Math.Round(curr_z, 3) == Math.Round(Double.Parse(dataF[row][4]), 3)))
            {
                lat = Double.Parse(dataF[row][0]);
                lon = Double.Parse(dataF[row][1]);
                height = Double.Parse(dataF[row][2]);
                slope = Double.Parse(dataF[row][6]);
                elevation = Double.Parse(dataF[row][7]);
                azimuth = Double.Parse(dataF[row][8]);
            }
        }
        //Debug.Log("Lat: " + lat+ " Lon: "+ lon+ " H: " + height+ slope+ elevation+ azimuth);

        theText.text = ("Latitude: " + lat + " | Longitude: " + lon + "\nX: " + curr_x + " | Y: " + curr_z + " | Height: " + height + "\nElevation: " + elevation + " | Azimuth: " + azimuth);
    }
}