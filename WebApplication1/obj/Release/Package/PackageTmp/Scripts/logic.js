
        //$("#resForm").submit(function () {
        //    //+ $.post(url, $('#resform').serialize(),
        //    google.charts.load('current', { packages: ['corechart', 'line'] });
        //    google.charts.setOnLoadCallback(drawBasic);
        //    function drawBasic() {

        //        var data = new google.visualization.DataTable();
        //        data.addColumn('number', 'X');
        //        data.addColumn('number', 'Y');

        //        data.addRows([
        //            [-5, 4], [-2, 1], [0, 0], [2, 1], [5, 4]
        //        ]);

        //        var options = {
        //            hAxis: {
        //                title: 'Time'
        //            },
        //            vAxis: {
        //                title: 'Popularity'
        //            }
        //        };

        //        var chart = new google.visualization.LineChart(document.getElementById('chart_div'));

        //        chart.draw(data, options)
        //    }

        //});



//<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
//<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

var dataForChart;

$('#resForm').submit(function (event) {
    //function validate_form() {
    //    valid = true;

    //    if (document.resForm.coefficientA.value == "") {
    //        alert("Пожалуйста заполните поле.");
    //        valid = false;
    //    }

    //    return valid;
    //}
    event.preventDefault();
    var $form = $(this),
        url = $form.attr('action');

    $.post(url, $('#resForm').serialize(),
        function (jsonData) {
            console.log(jsonData);
            dataForChart = jsonData;
            drawChart();
        });
});

google.charts.load('current', { 'packages': ['corechart', 'line'] });

function drawChart() {
    var data = new google.visualization.DataTable();
    data.addColumn('number', 'X');
    data.addColumn('number', 'Y');

    for (var i = 0; i < dataForChart.length; i++) {
        data.addRow([dataForChart[i].PointX, dataForChart[i].PointY]);
    }

    var options = {
        title: 'The Porabolic function',
        titleTextStyle: {
            color: '#999999',
            fontSize: 20,
        },
     
        width: 600,
        height:500,
        lineWidth: 4,
        colors: ['#DEAE51'],
        curveType: 'function',
        legend: { position: 'right' },
        legendTextStyle:{
            color: '#999999',
            fontSize: 16,
        },
        hAxis: {
            title: 'X',
            gridlines: {
                count: 10,
            },
            textStyle: {
                color: '#999999',
                fontSize: 14,
            },
            titleTextStyle: {
                color: '#999999',
                fontSize: 16,
            }
           
        },
        vAxis: {
            title: 'Y',
             gridlines: {
                count: 10,
            },
                 textStyle: {
                 color: '#999999',
                 fontSize: 14,
             },
             titleTextStyle: {
                 color: '#999999',
                 fontSize: 16,
             }
        },
        backgroundColor: '#383E46',
    };
 


    var chart = new google.visualization.LineChart(document.getElementById('chart_div'));

    chart.draw(data, options);
}

//var dataForChart;

//$('#resForm').submit(function (event) {
//    event.preventDefault();
//    var $form = $(this),
//        url = $form.attr('action');

//    var jqxhr = $.post(url, $('#resForm').serialize(),
//        function (jsonData) {
//            console.log(jsonData);
//            dataForChart = jsonData;
//            drawChart();
//        });
//});

//google.charts.load('current', { 'packages': ['corechart', 'line'] });

//function drawChart() {
//    var data = new google.visualization.DataTable();
//    data.addColumn('number', 'X');
//    data.addColumn('number', 'Y');

//    for (var i = 0; i < dataForChart.length; i++) {
//        data.addRow([dataForChart[i].PointX, dataForChart[i].PointY]);
//    }

//    var options = {
//        title: 'The Porabolic function',
//        curveType: 'function',
//        legend: { position: 'right' },
//        hAxis: {
//            title: 'X'
//        },
//        vAxis: {
//            title: 'Y'
//        }
//    };

//    var chart = new google.visualization.LineChart(document.getElementById('chart_div'));

//    chart.draw(data, options);
//}