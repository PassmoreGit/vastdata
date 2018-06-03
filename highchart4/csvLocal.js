Highcharts.chart('container', {
    chart: {
        type: 'column'
    },
    data: {
        // enablePolling: true,
        csvURL: window.location.origin + 'data.csv'
    },
    title: {
        text: 'Fruit Consumption'
    },
    yAxis: {
        title: {
            text: 'Units'
        }
    }
});