$(function () {
    debugger;
    $("#grid").jqGrid
    ({
        url: "/EmployeesJQG/GetValues",
        datatype: 'json',
        mtype: 'Get',
        //table header name

        colNames: ['Id', 'Name', 'Address', 'Gender', 'Company', 'Designation'],
        //colModel takes the data from controller and binds to grid   
        colModel: [
          {
              key: true,
              hidden: true,
              name: 'Id',
              index: 'Id',
              editable: true
          }, {
              key: false,
              name: 'Name',
              index: 'Name',
              editable: true
          }, {
              key: false,
              name: 'Address',
              index: 'Address',
              editable: true
          },
          {
              key: false,
              name: 'Gender',
              index: 'Gender',
              editable: true
          },
          {
              key: false,
              name: 'Company',
              index: 'Company',
              editable: true
          },
          {
              key: false,
              name: 'Designation',
              index: 'Designation',
              editable: true
          }
        ],

        pager: jQuery('#pager'),
        rowNum: 4,
        rowList: [4, 8, 12, 16],
        height: '100%',
        viewrecords: true,
        caption: 'Jq grid sample Application',
        emptyrecords: 'No records to display',
        jsonReader:
        {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
        //pager-you have to choose here what icons should appear at the bottom  
        //like edit,create,delete icons  
    }).navGrid('#pager',
    {
        edit: true,
        add: true,
        del: true,
        search: false,
        refresh: true
    }, {
        // edit options  
        zIndex: 100,
        url: '/EmployeesJQG/Edit',
        closeOnEscape: true,
        closeAfterEdit: true,
        recreateForm: true,
        afterComplete: function (response) {
            if (response.responseText) {
                alert(response.responseText);
            }
        }
    }, {
        // add options  
        zIndex: 100,
        url: "/EmployeesJQG/Create",
        closeOnEscape: true,
        closeAfterAdd: true,
        afterComplete: function (response) {
            if (response.responseText) {
                alert(response.responseText);
            }
        }
    },

    {
        // delete options  
        zIndex: 100,
        url: "/EmployeesJQG/Delete",
        closeOnEscape: true,
        closeAfterDelete: true,
        recreateForm: true,
        msg: "Are you sure you want to delete this student?",
        afterComplete: function (response) {
            if (response.responseText) {
                alert(response.responseText);
            }
        }
    });

});