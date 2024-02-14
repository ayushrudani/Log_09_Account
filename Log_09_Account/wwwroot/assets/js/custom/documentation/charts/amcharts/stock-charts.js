"use strict";var KTGeneralAmChartsStock=function(){const e=getComputedStyle(document.documentElement).getPropertyValue("--kt-body-color"),a=getComputedStyle(document.documentElement).getPropertyValue("--kt-body-bg");return{init:function(){am5.ready((function(){var t=am5.Root.new("kt_amcharts_1");t.setThemes([am5themes_Animated.new(t)]);var l=t.container.children.push(am5xy.XYChart.new(t,{panX:!0,panY:!1,wheelX:"panX",wheelY:"zoomX",layout:t.verticalLayout}));l.get("colors").set("step",2);var r=am5xy.AxisRendererY.new(t,{opposite:!0});r.labels.template.setAll({centerY:am5.percent(100),maxPosition:.98,fill:e});var n=l.yAxes.push(am5xy.ValueAxis.new(t,{renderer:r,height:am5.percent(30),layer:5}));n.axisHeader.set("paddingTop",10),n.axisHeader.children.push(am5.Label.new(t,{text:"Volume",fontWeight:"bold",paddingTop:5,paddingBottom:5}));var i=am5xy.AxisRendererY.new(t,{opposite:!0,pan:"zoom"});i.labels.template.setAll({centerY:am5.percent(100),maxPosition:.98,fill:e});var o=l.yAxes.push(am5xy.ValueAxis.new(t,{renderer:i,height:am5.percent(70),maxDeviation:1}));o.axisHeader.children.push(am5.Label.new(t,{text:"Value",fontWeight:"bold",paddingBottom:5,paddingTop:5}));var s=am5xy.AxisRendererX.new(t,{pan:"zoom"});s.labels.template.setAll({minPosition:.01,maxPosition:.99,fill:e});var m=l.xAxes.push(am5xy.DateAxis.new(t,{groupData:!0,maxDeviation:.5,baseInterval:{timeUnit:"day",count:1},renderer:s}));m.set("tooltip",am5.Tooltip.new(t,{}));var u=l.series.push(am5xy.LineSeries.new(t,{name:"XTD",valueYField:"price1",calculateAggregates:!0,valueXField:"date",xAxis:m,yAxis:o,legendValueText:"{valueY}"}));u.set("tooltip",am5.Tooltip.new(t,{getFillFromSprite:!1,getStrokeFromSprite:!0,getLabelFillFromSprite:!0,autoTextColor:!1,pointerOrientation:"horizontal",labelText:"{name}: {valueY} {valueYChangePercent.formatNumber('[#00ff00]+#,###.##|[#ff0000]#,###.##|[#999999]0')}%"})).get("background").set("fill",a);var d=l.get("colors").getIndex(0),p=l.series.push(am5xy.ColumnSeries.new(t,{name:"XTD",fill:d,stroke:d,valueYField:"quantity",valueXField:"date",valueYGrouped:"sum",xAxis:m,yAxis:n,legendValueText:"{valueY}",tooltip:am5.Tooltip.new(t,{labelText:"{valueY}"})}));p.columns.template.setAll({strokeWidth:.2,strokeOpacity:1,stroke:am5.color(16777215)}),o.axisHeader.children.push(am5.Legend.new(t,{useDefaultMarker:!0})).data.setAll([u]),n.axisHeader.children.push(am5.Legend.new(t,{useDefaultMarker:!0})).data.setAll([p]),l.rightAxesContainer.set("layout",t.verticalLayout),l.set("cursor",am5xy.XYCursor.new(t,{}));var x=l.set("scrollbarX",am5xy.XYChartScrollbar.new(t,{orientation:"horizontal",height:50})),h=x.chart.xAxes.push(am5xy.DateAxis.new(t,{groupData:!0,groupIntervals:[{timeUnit:"week",count:1}],baseInterval:{timeUnit:"day",count:1},renderer:am5xy.AxisRendererX.new(t,{})})),c=x.chart.yAxes.push(am5xy.ValueAxis.new(t,{renderer:am5xy.AxisRendererY.new(t,{})})),y=x.chart.series.push(am5xy.LineSeries.new(t,{valueYField:"price1",valueXField:"date",xAxis:h,yAxis:c}));y.fills.template.setAll({visible:!0,fillOpacity:.3});for(var g=[],A=1e3,v=1e4,w=1;w<5e3;w++)(A+=Math.round((Math.random()<.5?1:-1)*Math.random()*20))<100&&(A=100),(v+=Math.round((Math.random()<.5?1:-1)*Math.random()*500))<0&&(v*=-1),g.push({date:new Date(2010,0,w).getTime(),price1:A,quantity:v});u.data.setAll(g),p.data.setAll(g),y.data.setAll(g),l.appear(1e3,100)})),am5.ready((function(){var t=am5.Root.new("kt_amcharts_2");t.setThemes([am5themes_Animated.new(t)]);var l=t.container.children.push(am5xy.XYChart.new(t,{panX:!0,panY:!1,wheelX:"panX",wheelY:"zoomX",layout:t.verticalLayout}));l.get("colors").set("step",2);var r=am5xy.AxisRendererY.new(t,{opposite:!0,pan:"zoom"});r.labels.template.setAll({centerY:am5.percent(100),maxPosition:.98,fill:e});var n=l.yAxes.push(am5xy.ValueAxis.new(t,{renderer:r,maxDeviation:1,extraMin:.2})),i=am5xy.AxisRendererY.new(t,{opposite:!0});i.labels.template.setAll({forceHidden:!0,fill:e}),i.grid.template.setAll({forceHidden:!0});var o=l.yAxes.push(am5xy.ValueAxis.new(t,{renderer:i,height:am5.percent(25),layer:5,centerY:am5.p100,y:am5.p100}));o.axisHeader.set("paddingTop",10);var s=am5xy.AxisRendererX.new(t,{});s.labels.template.setAll({minPosition:.01,maxPosition:.99,fill:e});var m=l.xAxes.push(am5xy.DateAxis.new(t,{groupData:!0,baseInterval:{timeUnit:"day",count:1},renderer:s}));m.set("tooltip",am5.Tooltip.new(t,{themeTags:["axis"]}));var u=l.series.push(am5xy.LineSeries.new(t,{name:"XTD",valueYField:"price1",calculateAggregates:!0,valueYShow:"valueYChangeSelectionPercent",valueXField:"date",xAxis:m,yAxis:n,legendValueText:"{valueY}"})),d=l.series.push(am5xy.LineSeries.new(t,{name:"BTD",valueYField:"price2",calculateAggregates:!0,valueYShow:"valueYChangeSelectionPercent",valueXField:"date",xAxis:m,yAxis:n,legendValueText:"{valueY}"}));u.set("tooltip",am5.Tooltip.new(t,{getFillFromSprite:!1,getStrokeFromSprite:!0,getLabelFillFromSprite:!0,autoTextColor:!1,pointerOrientation:"horizontal",labelText:"{name}: {valueY} {valueYChangePercent.formatNumber('[#00ff00]+#,###.##|[#ff0000]#,###.##|[#999999]0')}%"})).get("background").set("fill",a),d.set("tooltip",am5.Tooltip.new(t,{getFillFromSprite:!1,getStrokeFromSprite:!0,getLabelFillFromSprite:!0,autoTextColor:!1,pointerOrientation:"horizontal",labelText:"{name}: {valueY} {valueYChangePercent.formatNumber('[#00ff00]+#,###.##|[#ff0000]#,###.##|[#999999]0')}%"})).get("background").set("fill",a);var p=l.get("colors").getIndex(0),x=l.series.push(am5xy.ColumnSeries.new(t,{name:"XTD",fill:p,stroke:p,valueYField:"quantity",valueXField:"date",valueYGrouped:"sum",xAxis:m,yAxis:o,legendValueText:"{valueY}",tooltip:am5.Tooltip.new(t,{labelText:"{valueY}"})}));x.columns.template.setAll({width:am5.percent(40),strokeWidth:.2,strokeOpacity:1,stroke:am5.color(16777215)});var h=l.plotContainer.children.push(am5.Legend.new(t,{useDefaultMarker:!0}));h.labels.template.setAll({fill:e}),h.valueLabels.template.setAll({fill:e}),h.data.setAll([u,d]),l.set("cursor",am5xy.XYCursor.new(t,{}));var c=l.set("scrollbarX",am5xy.XYChartScrollbar.new(t,{orientation:"horizontal",height:50})),y=c.chart.xAxes.push(am5xy.DateAxis.new(t,{groupData:!0,groupIntervals:[{timeUnit:"week",count:1}],baseInterval:{timeUnit:"day",count:1},renderer:am5xy.AxisRendererX.new(t,{})})),g=c.chart.yAxes.push(am5xy.ValueAxis.new(t,{renderer:am5xy.AxisRendererY.new(t,{})})),A=c.chart.series.push(am5xy.LineSeries.new(t,{valueYField:"price1",valueXField:"date",xAxis:y,yAxis:g}));A.fills.template.setAll({visible:!0,fillOpacity:.3});for(var v=[],w=1e3,Y=2e3,f=1e4,b=1;b<5e3;b++)(w+=Math.round((Math.random()<.5?1:-1)*Math.random()*20))<100&&(w=100),(Y+=Math.round((Math.random()<.5?1:-1)*Math.random()*20))<100&&(Y=100),(f+=Math.round((Math.random()<.5?1:-1)*Math.random()*500))<0&&(f*=-1),v.push({date:new Date(2010,0,b).getTime(),price1:w,price2:Y,quantity:f});u.data.setAll(v),d.data.setAll(v),x.data.setAll(v),A.data.setAll(v),l.appear(1e3,100)})),am5.ready((function(){var t=am5.Root.new("kt_amcharts_3");t.setThemes([am5themes_Animated.new(t)]);var l=t.container.children.push(am5xy.XYChart.new(t,{panX:!0,panY:!1,wheelX:"panX",wheelY:"zoomX",layout:t.verticalLayout}));l.get("colors").set("step",2);var r=am5xy.AxisRendererY.new(t,{inside:!0});r.labels.template.setAll({centerY:am5.percent(100),maxPosition:.98,fill:e});var n=l.yAxes.push(am5xy.ValueAxis.new(t,{renderer:r,height:am5.percent(70)}));n.axisHeader.children.push(am5.Label.new(t,{text:"Value",fontWeight:"bold",paddingBottom:5,paddingTop:5}));var i=am5xy.AxisRendererY.new(t,{inside:!0});i.labels.template.setAll({centerY:am5.percent(100),maxPosition:.98,fill:e});var o=l.yAxes.push(am5xy.ValueAxis.new(t,{renderer:i,height:am5.percent(30),layer:5,numberFormat:"#a"}));o.axisHeader.set("paddingTop",10),o.axisHeader.children.push(am5.Label.new(t,{text:"Volume",fontWeight:"bold",paddingTop:5,paddingBottom:5}));var s=am5xy.AxisRendererX.new(t,{});s.labels.template.setAll({minPosition:.01,maxPosition:.99,minGridDistance:40,fill:e});var m=l.xAxes.push(am5xy.DateAxis.new(t,{groupData:!0,baseInterval:{timeUnit:"day",count:1},renderer:s}));m.set("tooltip",am5.Tooltip.new(t,{}));var u=a,d=l.series.push(am5xy.CandlestickSeries.new(t,{fill:u,clustered:!1,calculateAggregates:!0,stroke:u,name:"MSFT",xAxis:m,yAxis:n,valueYField:"Close",openValueYField:"Open",lowValueYField:"Low",highValueYField:"High",valueXField:"Date",lowValueYGrouped:"low",highValueYGrouped:"high",openValueYGrouped:"open",valueYGrouped:"close",legendValueText:"open: {openValueY} low: {lowValueY} high: {highValueY} close: {valueY}",legendRangeValueText:"{valueYClose}"}));d.set("tooltip",am5.Tooltip.new(t,{getFillFromSprite:!1,getStrokeFromSprite:!0,getLabelFillFromSprite:!0,autoTextColor:!1,pointerOrientation:"horizontal",labelText:"{name}: {valueY} {valueYChangePreviousPercent.formatNumber('[#00ff00]+#,###.##|[#ff0000]#,###.##|[#999999]0')}%"})).get("background").set("fill",a);var p=l.get("colors").getIndex(0),x=l.series.push(am5xy.ColumnSeries.new(t,{name:"MSFT",clustered:!1,fill:p,stroke:p,valueYField:"Volume",valueXField:"Date",valueYGrouped:"sum",xAxis:m,yAxis:o,legendValueText:"{valueY}",tooltip:am5.Tooltip.new(t,{labelText:"{valueY}"})}));x.columns.template.setAll({}),n.axisHeader.children.push(am5.Legend.new(t,{useDefaultMarker:!0})).data.setAll([d]),o.axisHeader.children.push(am5.Legend.new(t,{useDefaultMarker:!0})).data.setAll([x]),l.leftAxesContainer.set("layout",t.verticalLayout),l.set("cursor",am5xy.XYCursor.new(t,{}));var h=l.set("scrollbarX",am5xy.XYChartScrollbar.new(t,{orientation:"horizontal",height:50})),c=h.chart.xAxes.push(am5xy.DateAxis.new(t,{groupData:!0,groupIntervals:[{timeUnit:"week",count:1}],baseInterval:{timeUnit:"day",count:1},renderer:am5xy.AxisRendererX.new(t,{})})),y=h.chart.yAxes.push(am5xy.ValueAxis.new(t,{renderer:am5xy.AxisRendererY.new(t,{})})),g=h.chart.series.push(am5xy.LineSeries.new(t,{valueYField:"Adj Close",valueXField:"Date",xAxis:c,yAxis:y}));g.fills.template.setAll({visible:!0,fillOpacity:.3}),am5.net.load("https://www.amcharts.com/wp-content/uploads/~/assets/stock/MSFT.csv").then((function(e){var a=am5.CSVParser.parse(e.response,{delimiter:",",reverse:!0,skipEmpty:!0,useColumnNames:!0});am5.DataProcessor.new(t,{dateFields:["Date"],dateFormat:"yyyy-MM-dd",numericFields:["Open","High","Low","Close","Adj Close","Volume"]}).processMany(a),console.log(a),d.data.setAll(a),x.data.setAll(a),g.data.setAll(a)})),l.appear(1e3,100)}))}}}();KTUtil.onDOMContentLoaded((function(){KTGeneralAmChartsStock.init()}));