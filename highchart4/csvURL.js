Highcharts.chart('container', {
    chart: {
        type: 'line',
        height: 600
    },
    title: {
        text: 'Vast 2018 Data'
    },
   // legend: {
   //     enabled: false
   // },
   // subtitle: {
  //      text: 'Instance Load'
  //  },
    data: {
       // csvURL: 'https://demo-live-data.highcharts.com/vs-load.csv',
      // csvURL: 'https://rawgit.com/PassmoreGit/vastdata/master/vs-loadpp.csv',
       // csvURL: 'https://raw.githubusercontent.com/PassmoreGit/vastdata/master/AcharaAmmonium2.csv',
     //  csvURL: 'https://rawgit.com/PassmoreGit/vastdata/master/AcharaAmmonium3.csv',
      // csvURL: 'https://rawgit.com/PassmoreGit/vastdata/master/AcharaAmmonium4.csv',
      //https://rawgit.com/PassmoreGit/vastdata/master/AcharaAmmonium4.csv
     //csvURL: 'https://rawgit.com/PassmoreGit/vastdata/master/AcharaAmmonium5.csv',
    // csvURL: 'https://rawgit.com/PassmoreGit/vastdata/master/AcharaAmmonium8.csv',
    // csvURL: 'http://localhost:8000/git/loadpp.csv',
    //  csvURL: 'http://localhost:8000/git/AcharaAmmonium8.csv',
      csvURL: 'http://localhost:8000/git/AcharaAll.csv',
       // enablePolling: false,
       // dataRefreshRate: 1
    },
  //  plotOptions: {
  //      bar: {
  //          colorByPoint: true
   //     },
   //     series: {
      
           // dataLabels: {
           //     enabled: true,
           //     format: '{point.y:.0f}%'
           // }
    //    }
   // },
   // tooltip: {
   //     valueDecimals: 100,
   //     valueSuffix: '%'
   // },
  //  xAxis: {
       // type: 'category',
       // labels: {
       //     style: {
        //        fontSize: '10px'
        //    }
        //}
   // },
   // yAxis: {
       // max: 1,
       // title: false,
       // plotBands: [{
       //     from: 0,
       //     to: 30,
       //     color: '#E8F5E9'
       // }, {
       //     from: 30,
       //     to: 70,
       //     color: '#FFFDE7'
       // }, {
       //     from: 70,
      //      to: 100,
      //      color: "#FFEBEE"
      //  }]
   // }
});

