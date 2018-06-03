   
    function sum(a, b) {
                return (a + b);
    }

   
    function showMessage(from, text) { // arguments: from, text
         alert(from + ': ' + text)
    }
            
    function checkAge(age) {
    if (age > 18) {
            return true;
        } else {
            return confirm('Got a permission from the parents?');
        }
    }
  
function makeUser(name, age) {
  return {
    name,
    age
    // ...other properties
  };
}

var mytext;
function readTextFile(file)
{
    var rawFile = new XMLHttpRequest();
    rawFile.open("GET", file, false);
    rawFile.onreadystatechange = function ()
    {
        if(rawFile.readyState === 4)
        {
            if(rawFile.status === 200 || rawFile.status == 0)
            {
              var allText = rawFile.responseText;
               // alert(allText);
               mytext=allText;
               if(rawFile.onloadend){
               return (allText);
               }
            }
        }
    }
    rawFile.send(null);
}

//readTextFile("file:///e:/VAST2018/highchart/file.txt");
//readTextFile("https://cdn.rawgit.com/highcharts/highcharts/057b672172ccc6c08fe7dbb27fc17ebca3f5b770/samples/data/usdeur.json");
//let txt=readTextFile("https://rawgit.com/PassmoreGit/vastdata/master/Boonsong%20Lekagul%20waterways%20readings.csv");
//var txt=readTextFile(//"https://rawgit.com/PassmoreGit/vastdata/master/Boonsong%20Lekagul%20waterways%20readings.csv");
var txt=readTextFile("https://rawgit.com/PassmoreGit/vastdata/master/AcharaAmmonium.csv");


var test=mytext;

let tyyy=8.999;

function readSingleFile(evt) {
    //Retrieve the first (and only!) File from the FileList object
    var f = evt.target.files[0]; 

    if (f) {
      var r = new FileReader();
      r.onload = function(e) { 
	      var contents = e.target.result;
        alert( "Got the file.n" 
              +"name: " + f.name + "n"
              +"type: " + f.type + "n"
              +"size: " + f.size + " bytesn"
              + "starts with: " + contents.substr(1, contents.indexOf("n"))
        );  
      }
      r.readAsText(f);
    } else { 
      alert("Failed to load file");
  }
}

document.getElementById('fileinput').addEventListener('change', readSingleFile, false);
