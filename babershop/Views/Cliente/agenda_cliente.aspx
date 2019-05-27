<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agenda_cliente.aspx.cs" Inherits="babershop.Views.Cliente.agenda_cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title></title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
   
    <script src="../../js/jquery.min.js"></script>
    <script src="../../js/moment.min.js"></script>

    <link href="../../css/fullcalendar.min.css" rel="stylesheet" />
    <script src="../../js/fullcalendar.min.js"></script>
    <script src="../../js/es.js"></script>
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>

    <style type='text/css'>
        body
        {
            margin-top: 40px;
            text-align: center;
            font-size: 14px;
            font-family: "Lucida Grande" ,Helvetica,Arial,Verdana,sans-serif;
        }
        #calendar
        {
            width: 900px;
            margin: 0 auto;
        }
        /* css for timepicker */
        .ui-timepicker-div dl
        {
            text-align: left;
        }
        .ui-timepicker-div dl dt
        {
            height: 25px;
        }
        .ui-timepicker-div dl dd
        {
            margin: -25px 0 10px 65px;
        }
        .style1
        {
            width: 100%;
        }
        
        /* table fields alignment*/
        .alignRight
        {
        	text-align:right;
        	padding-right:10px;
        	padding-bottom:10px;
        }
        .alignLeft
        {
        	text-align:left;
        	padding-bottom:10px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        
            
        <div id="calendar">
    
        </div>
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                       <%-- <button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                        <h4 class="modal-title" id="eventTitle"></h4>
                    </div>
                    <asp:Label ID="idcita" runat="server" Text=""></asp:Label>
                    <div class="modal-body">
                       

                        <p id="pDetails"></p>
                    </div>
                    <div class="modal-footer">
                        
                         
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

      <%--  <link href="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.min.css" rel="stylesheet" />
        <link href="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.print.css" rel="stylesheet" media="print" />
        <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.min.js"></script>--%>



        <script>
        function Confirm() {
            $('#myModal').modal('show');
            return true;
        };
    </script>




        <script>
            $(document).ready(function () {
                var events = [];
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "agenda_cliente.aspx/GetEvents",
                    success: function (data) {
                        
                        $.each(data.d, function (i, v) {
                            events.push({
                                EventId:v.EventId,
                                title: v.Subject,
                                description: v.Description,
                                start: moment(v.Start),
                                end: v.End != null ? moment(v.End) : null,
                                color: v.ThemeColor,
                                allDay: v.IsFullDay
                            });
                        })

                        GenerateCalendar(events);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Status: " + textStatus); alert("Error: " + XMLHttpRequest.responseText);
                    }
                    //error: function (error) {

                    //    alert('failed');
                    //}
                })

                function GenerateCalendar(events) {
                    //$('#calendar').fullCalendar('destroy');
                    $('#calendar').fullCalendar({
                        locale: 'es',
                        contentHeight: 400,
                        defaultDate: new Date(),
                        timeFormat: 'h(:mm)a',
                        
                        header: {
                            left: ' Miboton,prev,next ',
                            center: 'title',
                            right: 'month,basicWeek,basicDay,agenda'

                        },
                        customButtons: {
                            Miboton: {
                                text: "Volver", click: function () {
                                    location.href = "../../Views/Administrador/Inicio.aspx";
                                }
                            }

                        },
                        eventLimit: true,
                        eventColor: '#378006',
                        events: events,
                        eventClick: function (calEvent, jsEvent, view) {
                            $('#myModal #eventTitle').text(calEvent.title);
                            $('#myModal #idcita').text(calEvent.EventId);
                            var $description = $('<div/>');
                            $description.append($('<p/>').html('<b>Fecha:</b>' + calEvent.start.format("DD-MMM-YYYY HH:mm a")));
                            if (calEvent.end != null) {
                                $description.append($('<p/>').html('<b>End:</b>' + calEvent.end.format("DD-MMM-YYYY HH:mm a")));
                            }
                            $description.append($('<p/>').html('<b>Servicio:</b>' + calEvent.description));
                            $('#myModal #pDetails').empty().html($description);

                            $('#myModal').modal();
                        }
                    })
                }
            })
        </script>


    </form>




</body>
    
</html>
