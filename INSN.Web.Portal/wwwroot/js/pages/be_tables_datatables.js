﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*!
 * codebase - v5.5.0
 * @author pixelcave - https://pixelcave.com
 * Copyright (c) 2023
 */
!
    function () {
        class a {
            static initDataTables() {
                jQuery.extend(jQuery.fn.dataTable.ext.classes, {
                    sWrapper: "dataTables_wrapper dt-bootstrap5",
                    sFilterInput: "form-control",
                    		sLengthSelect: "form-select"
                }), jQuery.extend(!0, jQuery.fn.dataTable.defaults, {
                    language: {
                        lengthMenu: "_MENU_",
                        search: "_INPUT_",
                        searchPlaceholder: "Buscar..",
                        info: "Página <strong>_PAGE_</strong> de <strong>_PAGES_</strong>",
                        paginate: {
                            first: '<i class="fa fa-angle-double-left"></i>',
                            previous: '<i class="fa fa-angle-left"></i>',
                            next: '<i class="fa fa-angle-right"></i>',
                            last: '<i class="fa fa-angle-double-right"></i>'
                        }
                    }
                }), jQuery.extend(!0, jQuery.fn.DataTable.Buttons.defaults, {
                    dom: {
                        button: {
                            className: "btn btn-sm btn-primary"
                        }
                    }
                }), jQuery(".js-dataTable-full").DataTable({
                    pageLength: 5,
                    lengthMenu: [
                        [5, 10, 20],
                        [5, 10, 20]
                    ],
                    autoWidth: !1
                }), jQuery(".js-dataTable-buttons").DataTable({
                    pageLength: 5,
                    lengthMenu: [
                        [5, 10, 20],
                        [5, 10, 20]
                    ],
                    autoWidth: !1,
                    buttons: ["copy", "csv", "excel", "pdf", "print"],
                    dom: "<'row'<'col-sm-12'<'text-center bg-body-light py-2 mb-2'B>>><'row'<'col-sm-12 col-md-6'l><'col-sm-12 col-md-6'f>><'row'<'col-sm-12'tr>><'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>"
                }), jQuery(".js-dataTable-full-pagination").DataTable({
                    pagingType: "full_numbers",
                    pageLength: 5,
                    lengthMenu: [
                        [5, 10, 20],
                        [5, 10, 20]
                    ],
                    autoWidth: !1
                }), jQuery(".js-dataTable-simple").DataTable({
                    pageLength: 5,
                    lengthMenu: !1,
                    searching: !1,
                    autoWidth: !1,
                    dom: "<'row'<'col-sm-12'tr>><'row'<'col-sm-6'i><'col-sm-6'p>>"
                }),
                //#region [JYataco - Eliminar]
                   /*INICIO JYATACO - eliminar paginador y navegador de paginas*/

                    //	jQuery(".js-dataTable-responsive").DataTable({
                    //	pagingType: "full_numbers",
                    //	pageLength: 10,
                    //	lengthMenu: [
                    //		[10, 20, 40],
                    //		[10, 20, 40]
                    //	],
                    //	autoWidth: !1,
                    //	responsive: !0
                    //})

                    jQuery(".js-dataTable-responsive").DataTable({
                        paging: true, // Elimina el paginador
                        ordering: false, // Desactiva la ordenación
                        searching: false, // Desactiva la opción de búsqueda
                        info: false, // Elimina la información de "Página 1 de 2"
                        lengthMenu: [
                            [10, 20, 40],
                            [10, 20, 40]
                        ],
                        autoWidth: false,                   
                        dom: 'frtilp' // Coloca el menú de longitud junto con la paginación
                    }).buttons().container().appendTo('#datatable-buttons_wrapper .col-md-6:eq(0)');
       

                /*FIN JYATACO - eliminar paginador y navegador de paginas*/
                //#endregion
            }
            static init() {
                this.initDataTables()
            }
        }
        Codebase.onLoad(() => a.init());
    }();