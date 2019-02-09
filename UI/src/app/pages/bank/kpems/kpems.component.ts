import { Component, OnInit, ViewEncapsulation, } from '@angular/core';
import {NgxCarousel} from 'ngx-carousel';


import '../../../../assets/charts/amchart/amcharts.js';
import '../../../../assets/charts/amchart/gauge.js';
import '../../../../assets/charts/amchart/pie.js';
import '../../../../assets/charts/amchart/serial.js';
import '../../../../assets/charts/amchart/light.js';
import '../../../../assets/charts/amchart/ammap.js';
import '../../../../assets/charts/amchart/usaLow.js';

import '../../../../assets/charts/float/jquery.flot.js';
import '../../../../assets/charts/float/jquery.flot.categories.js';
import '../../../../assets/charts/float/curvedLines.js';
import '../../../../assets/charts/float/jquery.flot.tooltip.min.js';

declare var $: any;
declare const AmCharts: any;
@Component({
  selector: 'app-kpems',
  templateUrl: './kpems.component.html',
  styleUrls: [
    './kpems.component.scss',
    '../../../../assets/icon/icofont/css/icofont.scss'
  ]

})

// @ViewChild() slideshow
export class KpemsComponent implements OnInit {

  
  imgags: string[];
  imgagsBanner: string[];

  public carouselBannerItems: Array<any> = [];
  public carouselBanner: NgxCarousel;

  public carouselTileItems: Array<any> = [];
  public carouselTile: NgxCarousel;

  public carouselTileOneItems: Array<any> = [];
  public carouselTileOne: NgxCarousel;

  public carouselTileTwoItems: Array<any> = [];
  public carouselTileTwo: NgxCarousel;

  

  imagesUrl: any = []

  constructor() { }

  chartOption: any = {
    legend: {
      show: false
    },
    series: {
      label: '',
      curvedLines: {
        active: true,
        nrSplinePoints: 20
      },
    },
    tooltip: {
      show: true,
      content: 'x : %x | y : %y'
    },
    grid: {
      hoverable: true,
      borderWidth: 0,
      labelMargin: 0,
      axisMargin: 0,
      minBorderMargin: 0,
    },
    yaxis: {
      min: 0,
      max: 30,
      color: 'transparent',
      font: {
        size: 0,
      }
    },
    xaxis: {
      color: 'transparent',
      font: {
        size: 0,
      }
    }
  };

  ngOnInit() {

    
    {
      setTimeout(() => {
        const chart = AmCharts.makeChart('seo-ecommerce-barchart', {
          'type': 'serial',
          'theme': 'light',
          'marginTop': 0,
          'marginRight': 0,
          'dataProvider': [{
            'year': '1950',
            'value': -0.307
          }, {
            'year': '1951',
            'value': -0.168
          }, {
            'year': '1952',
            'value': -0.073
          }, {
            'year': '1953',
            'value': -0.027
          }, {
            'year': '1954',
            'value': -0.251
          }, {
            'year': '1955',
            'value': -0.281
          }, {
            'year': '1956',
            'value': -0.348
          }, {
            'year': '1957',
            'value': -0.074
          }, {
            'year': '1958',
            'value': -0.011
          }, {
            'year': '1959',
            'value': -0.074
          }, {
            'year': '1960',
            'value': -0.124
          }, {
            'year': '1961',
            'value': -0.024
          }, {
            'year': '1962',
            'value': -0.022
          }, {
            'year': '1963',
            'value': 0
          }, {
            'year': '1964',
            'value': -0.296
          }, {
            'year': '1965',
            'value': -0.217
          }, {
            'year': '1966',
            'value': -0.147
          }, {
            'year': '1967',
            'value': -0.15
          }, {
            'year': '1968',
            'value': -0.16
          }, {
            'year': '1969',
            'value': -0.011
          }, {
            'year': '1970',
            'value': -0.068
          }, {
            'year': '1971',
            'value': -0.19
          }, {
            'year': '1972',
            'value': -0.056
          }, {
            'year': '1973',
            'value': 0.077
          }, {
            'year': '1974',
            'value': -0.213
          }, {
            'year': '1975',
            'value': -0.17
          }, {
            'year': '1976',
            'value': -0.254
          }, {
            'year': '1977',
            'value': 0.019
          }, {
            'year': '1978',
            'value': -0.063
          }, {
            'year': '1979',
            'value': 0.05
          }, {
            'year': '1980',
            'value': 0.077
          }, {
            'year': '1981',
            'value': 0.12
          }, {
            'year': '1982',
            'value': 0.011
          }, {
            'year': '1983',
            'value': 0.177
          }, {
            'year': '1984',
            'value': -0.021
          }, {
            'year': '1985',
            'value': -0.037
          }, {
            'year': '1986',
            'value': 0.03
          }, {
            'year': '1987',
            'value': 0.179
          }, {
            'year': '1988',
            'value': 0.18
          }, {
            'year': '1989',
            'value': 0.104
          }, {
            'year': '1990',
            'value': 0.255
          }, {
            'year': '1991',
            'value': 0.21
          }, {
            'year': '1992',
            'value': 0.065
          }, {
            'year': '1993',
            'value': 0.11
          }, {
            'year': '1994',
            'value': 0.172
          }, {
            'year': '1995',
            'value': 0.269
          }, {
            'year': '1996',
            'value': 0.141
          }, {
            'year': '1997',
            'value': 0.353
          }, {
            'year': '1998',
            'value': 0.548
          }, {
            'year': '1999',
            'value': 0.298
          }, {
            'year': '2000',
            'value': 0.267
          }, {
            'year': '2001',
            'value': 0.411
          }, {
            'year': '2002',
            'value': 0.462
          }, {
            'year': '2003',
            'value': 0.47
          }, {
            'year': '2004',
            'value': 0.445
          }, {
            'year': '2005',
            'value': 0.47
          }],
          'valueAxes': [{
            'axisAlpha': 0,
            // 'gridAlpha': 0,
            'dashLength': 6,
            'position': 'left'
          }],
          'graphs': [{
            'id': 'g1',
            'balloonText': '[[category]]<br><b><span style="font-size:14px;">[[value]]</span></b>',
            'bullet': 'round',
            'bulletSize': 8,
            // 'fillAlphas': 0.1,
            'lineColor': '#448aff',
            'lineThickness': 2,
            'negativeLineColor': '#ff5252',
            'type': 'smoothedLine',
            'valueField': 'value'
          }],
          'chartScrollbar': {
            'graph': 'g1',
            'gridAlpha': 0,
            'color': '#888888',
            'scrollbarHeight': 55,
            'backgroundAlpha': 0,
            'selectedBackgroundAlpha': 0.1,
            'selectedBackgroundColor': '#888888',
            'graphFillAlpha': 0,
            'autoGridCount': true,
            'selectedGraphFillAlpha': 0,
            'graphLineAlpha': 0.2,
            'graphLineColor': '#c2c2c2',
            'selectedGraphLineColor': '#888888',
            'selectedGraphLineAlpha': 1
          },
          'chartCursor': {
            'categoryBalloonDateFormat': 'YYYY',
            'cursorAlpha': 0,
            'valueLineEnabled': true,
            'valueLineBalloonEnabled': true,
            'valueLineAlpha': 0.5,
            'fullWidth': true
          },
          'dataDateFormat': 'YYYY',
          'categoryField': 'year',
          'categoryAxis': {
            'minPeriod': 'YYYY',
            'gridAlpha': 0,
            'parseDates': true,
          },
        });
        chart.zoomToIndexes(Math.round(chart.dataProvider.length * 0.3), Math.round(chart.dataProvider.length * 0.55));
  
        $.plot($('#total-value-graph-1'), [{
          data: [
            [0, 20],
            [20, 10],
            [35, 18],
            [50, 12],
            [65, 25],
            [75, 10],
            [90, 20],
          ],
          color: '#fff',
          lines: {
            show: true,
            fill: true,
            lineWidth: 3
          },
          points: {
            show: false
          },
          curvedLines: {
            apply: true,
          }
        }], this.chartOption);
  
        $.plot($('#total-value-graph-2'), [{
          data: [
            [0, 10],
            [20, 20],
            [35, 18],
            [50, 25],
            [65, 12],
            [75, 10],
            [90, 20],
          ],
          color: '#fff',
          lines: {
            show: true,
            fill: true,
            lineWidth: 3
          },
          points: {
            show: false
          },
          curvedLines: {
            apply: true,
          }
        }], this.chartOption);
  
        $.plot($('#total-value-graph-3'), [{
          data: [
            [0, 20],
            [20, 10],
            [35, 25],
            [50, 18],
            [65, 18],
            [75, 10],
            [90, 12],
          ],
          color: '#fff',
          lines: {
            show: true,
            fill: true,
            lineWidth: 3
          },
          points: {
            show: false
          },
          curvedLines: {
            apply: true,
          }
        }], this.chartOption);
  
        $.plot($('#total-value-graph-4'), [{
          data: [
            [0, 18],
            [20, 10],
            [35, 20],
            [50, 10],
            [65, 12],
            [75, 25],
            [90, 20],
          ],
          color: '#fff',
          lines: {
            show: true,
            fill: true,
            lineWidth: 3
          },
          points: {
            show: false
          },
          curvedLines: {
            apply: true,
          }
        }], this.chartOption);
  
        $.plot($('#power-card-chart1'), [{
          data: [
            [0, 18],
            [20, 10],
            [35, 20],
            [50, 10],
            [65, 27],
            [75, 15],
            [90, 20],
          ],
          color: '#ff5252',
          lines: {
            show: true,
            fill: false,
            lineWidth: 3
          },
          points: {
            show: false
          },
          curvedLines: {
            apply: true,
          }
        }], this.chartOption);
  
        $.plot($('#power-card-chart2'), [{
          data: [
            [0, 10],
            [20, 25],
            [35, 27],
            [50, 10],
            [65, 20],
            [75, 10],
            [90, 18],
          ],
          color: '#448aff',
          lines: {
            show: true,
            fill: false,
            lineWidth: 3
          },
          points: {
            show: false
          },
          curvedLines: {
            apply: true,
          }
        }], this.chartOption);
  
      }, 75);
    }
    this.imgagsBanner = [
      'assets/images/slider/slide4.jpg',
      'assets/images/slider/slide3.jpg',
      'assets/images/slider/slide2.jpg',
      'assets/images/slider/slide1.jpg'
    ];
    this.carouselBanner = {
      grid: { xs: 1, sm: 1, md: 1, lg: 1, all: 0 },
      slide: 4,
      speed: 500,
      interval: 3000,
      point: {
        visible: true,
        pointStyles: `
          .ngxcarouselPoint {
            list-style-type: none;
            text-align: center;
            padding: 12px;
            margin: 0;
            white-space: nowrap;
            overflow: auto;
            position: absolute;
            width: 100%;
            bottom: 20px;
            left: 0;
            box-sizing: border-box;
          }
          .ngxcarouselPoint li {
            display: inline-block;
            border-radius: 999px;
            background: rgba(255, 255, 255, 0.55);
            padding: 5px;
            margin: 0 3px;
            transition: .4s ease all;
          }
          .ngxcarouselPoint li.active {
              background: white;
              width: 10px;
          }
        `
      },
      load: 2,
      custom: 'banner',
      touch: true,
      loop: true,
      easing: 'cubic-bezier(0, 0, 0.2, 1)'
    };
  

 
  }

  onmoveFn(data) {
    // console.log(data);
  }

  public carouselBannerLoad() {
    const len = this.carouselBannerItems.length;
    if (len <= 3) {
      for (let i = len; i < len + 4; i++) {
        this.carouselBannerItems.push(
          this.imgagsBanner[i]
        );
      }
    }
  }
  public carouselTileLoad() {
    const len = this.carouselTileItems.length;
    if (len <= 7) {
      for (let i = len; i < len + 8; i++) {
        this.carouselTileItems.push(
          this.imgags[i]
        );
      }
    }
  }

  public carouselTileOneLoad() {
    const len = this.carouselTileOneItems.length;
    if (len <= 7) {
      for (let i = len; i < len + 8; i++) {
        this.carouselTileOneItems.push(
          this.imgags[i]
        );
      }
    }
  }

  public carouselTileTwoLoad() {
    const len = this.carouselTileTwoItems.length;
    if (len <= 7) {
      for (let i = len; i < len + 8; i++) {
        this.carouselTileTwoItems.push(
          this.imgags[i]
        );
      }
    }
  }

/*Bar chart Start*/
type1 = 'bar';
data1 = {
  labels: [0, 1, 2, 3, 4, 5, 6, 7],
  datasets: [{
    label: 'My First dataset',
    backgroundColor: [
      'rgba(95, 190, 170, 0.99)',
      'rgba(95, 190, 170, 0.99)',
      'rgba(95, 190, 170, 0.99)',
      'rgba(95, 190, 170, 0.99)',
      'rgba(95, 190, 170, 0.99)',
      'rgba(95, 190, 170, 0.99)',
      'rgba(95, 190, 170, 0.99)'
    ],
    hoverBackgroundColor: [
      'rgba(26, 188, 156, 0.88)',
      'rgba(26, 188, 156, 0.88)',
      'rgba(26, 188, 156, 0.88)',
      'rgba(26, 188, 156, 0.88)',
      'rgba(26, 188, 156, 0.88)',
      'rgba(26, 188, 156, 0.88)',
      'rgba(26, 188, 156, 0.88)'
    ],
    data: [65, 59, 80, 81, 56, 55, 50],
  }, {
    label: 'My second dataset',
    backgroundColor: [
      'rgba(93, 156, 236, 0.93)',
      'rgba(93, 156, 236, 0.93)',
      'rgba(93, 156, 236, 0.93)',
      'rgba(93, 156, 236, 0.93)',
      'rgba(93, 156, 236, 0.93)',
      'rgba(93, 156, 236, 0.93)',
      'rgba(93, 156, 236, 0.93)'
    ],
    hoverBackgroundColor: [
      'rgba(103, 162, 237, 0.82)',
      'rgba(103, 162, 237, 0.82)',
      'rgba(103, 162, 237, 0.82)',
      'rgba(103, 162, 237, 0.82)',
      'rgba(103, 162, 237, 0.82)',
      'rgba(103, 162, 237, 0.82)',
      'rgba(103, 162, 237, 0.82)'
    ],
    data: [60, 69, 85, 91, 58, 50, 45],
  }]
};

options = {
  responsive: true,
  maintainAspectRatio: false,
};

/*Bar chart End*/
}
