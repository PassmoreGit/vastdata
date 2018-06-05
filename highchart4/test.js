var csv = 'ClearedMW' + '\n' +
'LoadHour,LoadValue' + '\n' +
'1.5,56454' + '\n' +
'2.5,55528' + '\n' +
'3,54365' + '\n' +
'4.5,54303' + '\n' +
'5.5,57194' + '\n' +
'6,64638' + '\n' +
'7,72471' + '\n' +
'8,73577' + '\n' +
'9,72793' + '\n' +
'10,73727' + '\n' +
'11,73947' + '\n' +
'12,75210' + '\n' +
'13,75574' + '\n' +
'14,76416' + '\n' +
'15,77524' + '\n' +
'16,77055' + '\n' +
'17,77144' + '\n' +
'18,76935' + '\n' +
'19,78950' + '\n' +
'20,76294' + '\n' +
'21,73941' + '\n' +
'22,69484' + '\n' +
'23,64090' + '\n' +
'24,59136' + '\n' +
'MediumTermLoadForecast' + '\n' +
'Hour_Ending,Load_Forecast' + '\n' +
'1,61919' + '\n' +
'2,60274' + '\n' +
'3,59235' + '\n' +
'4,58957' + '\n' +
'5,59251' + '\n' +
'6,62131' + '\n' +
'7,68116' + '\n' +
'8,72522' + '\n' +
'9,73751' + '\n' +
'10,74364' + '\n' +
'11,75215' + '\n' +
'12,76037' + '\n' +
'13,76819' + '\n' +
'14,77620' + '\n' +
'15,78038' + '\n' +
'16,78094' + '\n' +
'17,78007' + '\n' +
'18,78212' + '\n' +
'19,79157' + '\n' +
'20,78294' + '\n' +
'21,76054' + '\n' +
'22,72802' + '\n' +
'23,68596' + '\n' +
'24,64272';

var options = {
  chart: {
    renderTo: 'container',
  },
  series: [{
    	name:'',
      data:[]
    }, {
    	name:'',
      data:[]
    }
  ]
}
//
var i = 0;
var j = 0;
csv.split('\n').forEach((line) => {
	if(line.split(',').length == 1) {
  	options.series[i].name = line;
    i++;
    j = 0;
  } else {
  	if (j == 0) { j++; return; }
  	options.series[i-1].data[j] = line.split(',').map(el => Number(el));
    j++;
  }
});

// Clone options object
options = JSON.parse(JSON.stringify(options));
Highcharts.chart(options);