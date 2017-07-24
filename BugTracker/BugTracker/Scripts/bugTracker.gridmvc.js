﻿//function TypesFilterWidget() {
//	/***
//    * This method must return type of registered widget type in 'SetFilterWidgetType' method
//    */
//	this.getAssociatedTypes = function () {
//		return ["CustomTypesProblemFilterWidget"];
//	};
//	/***
//    * This method invokes when filter widget was shown on the page
//    */
//	this.onShow = function () {
//		/* Place your on show logic here */
//	};

//	this.showClearFilterButton = function () {
//		return true;
//	};

//	/***
//    * This method will invoke when user was clicked on filter button.
//    * container - html element, which must contain widget layout;
//    * lang - current language settings;
//    * typeName - current column type (if widget assign to multipile types, see: getAssociatedTypes);
//    * values - current filter values. Array of objects [{filterValue: '', filterType:'1'}];
//    * cb - callback function that must invoked when user want to filter this column. Widget must pass filter type and filter value.
//    * data - widget data passed from the server
//    */
//	this.onRender = function (container, lang, typeName, values, cb, data) {
//		//store parameters:
//		this.cb = cb;
//		this.container = container;
//		this.lang = lang;

//		//this filterwidget demo supports only 1 filter value for column column
//		this.value = values.length > 0 ? values[0] : { filterType: 1, filterValue: "" };

//		this.renderWidget(); //onRender filter widget
//		this.loadCustomers(); //load customer's list from the server
//		this.registerEvents(); //handle events
//	};

//	this.renderWidget = function () {
//		var html = '<p><i>This is custom filter widget demo.</i></p>\
//                    <p>Select customer to filter:</p>\
//                    <select style="width:250px;" class="grid-filter-type customerslist form-control">\
//                    </select>';
//		this.container.append(html);
//	};
//	/***
//    * Method loads all customers from the server via Ajax:
//    */
//	this.loadCustomers = function () {
//		this.fillCustomers(["Паша", "Саша", "Маша"]);
//		//var $this = this;
//		//$.post("/Home/GetCustomersNames", function (data) {
//		//	$this.fillCustomers(data.Items);
//		//});
//	};
//	/***
//    * Method fill customers select list by data
//    */
//	this.fillCustomers = function (items) {
//		var customerList = this.container.find(".customerslist");
//		for (var i = 0; i < items.length; i++) {
//			customerList.append('<option ' + (items[i] == this.value.filterValue ? 'selected="selected"' : '') + ' value="' + items[i] + '">' + items[i] + '</option>');
//		}
//	};
//	/***
//    * Internal method that register event handlers for 'apply' button.
//    */
//	this.registerEvents = function () {
//		//get list with customers
//		var customerList = this.container.find(".customerslist");
//		//save current context:
//		var $context = this;
//		//register onclick event handler
//		customerList.change(function () {
//			//invoke callback with selected filter values:
//			var values = [{ filterValue: $(this).val(), filterType: 1 /* Equals */ }];
//			$context.cb(values);
//		});
//	};

//}

$(document).ready(function () {
	//pageGrids.listApplications.addFilterWidget(new TypesFilterWidget());
    $(".grid-filter-btn").attr("title", "Добавить фильтр по полю");
    if (pageGrids != null)
        if (pageGrids.listApplications != null) {
            pageGrids.listApplications.onRowSelect(function (e) {
                $("#idApplication").val(e.row.Id);
                $("#detailsApplicationForm").submit();
            });
        }
}) 