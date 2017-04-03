var searchPanel = (function () {
    var validator;
    
    function onCheckedComboBoxClick (e, controlId) {
        comboBoxFacade.canselCloseOnClick(e);
        var checkedItems = comboBoxFacade.getCheckedItems(controlId);
        var text = checkedItems.texts.toString();
        comboBoxFacade.setTextById(controlId, text, true);
        $("#" + controlId + "_SelectedValues").val(checkedItems.values.toString());
        twinkleTextBox.updateDdlLabels(controlId, text);
    }

    function hideEmptyItemInCheckedComboBox() {
        $("." + comboBoxFacade.itemCheckBoxClassName + "[checkedname='']").hide();
    }

    function clearCheckedComboBox(controlId) {
        var checked = comboBoxFacade.getCheckedCheckBoxes(controlId);
        checked.removeAttr("checked");
        comboBoxFacade.setTextById(controlId, "", true);
        $("#" + controlId + "_SelectedValues").val("");
        twinkleTextBox.updateDdlLabels(controlId, "");
    }

    function hideSearchPanel() {
        $("#searchpanel").hide();
        var arrows = $("#spTogglePanel");
        arrows.find(".openArrow").show();
        arrows.find(".closeArrow").hide();
    }

    function regDocumentEvents() {
        $('body').click(hideSearchPanel);

        $('#searchpanel, .' + commonWidgetsFacade.listContainerClassName +
            ', .' + commonWidgetsFacade.calendarContainerClassName).click(function (event) {
            event.stopPropagation();
        });
        
        $('.lfSearchPanelTd').click(function (event) {
            searchPanel.toggle();
            event.stopPropagation();
        });
    }

    return {
        defaultGridName: "Grid",
        bSearchSimple: false,

        init: function () {
            twinkleTextBox.init();
            twinkleTextBox.addTooltip("span.spComboBox");
            regDocumentEvents();

            validator = validatorFacade.addForValidationSummary("panelForm");
        },

        hide: function () {
            hideSearchPanel();
        },


        getFilter: function () {
            var result = {};
            if (searchPanel.bSearchSimple)
                result = searchPanel.getFilterFromForm(result, "panelFormSimple");
            result = searchPanel.getFilterFromForm(result, "panelForm");
            return result;
        },

        requestEnd: function (e) {
            if (e.response.Data == undefined) {
                actions.redirect(bvUrls.getHomeUrl());
            }
            
            if ($("#idSelectUnselectAll").length > 0) {
                $("#idSelectUnselectAll")[0].checked = false;
            }

            if (!e.response.IgnoreTopMaxCount && e.response.Total >= e.response.SelectTopMaxCount) {
                bvDialog.showWarning(EIDSS.BvMessages.msgTooBigRecordsCount);
            }
        },

        getFilterFromForm: function (result, formName) {
            var a = $("#" + formName).serializeArray();
            $.each(a, function () {
                var isCheckedComboBox = $("#" + this.name + "_SelectedValues").length > 0;
                if (isCheckedComboBox) {
                    this.value = $("#" + this.name + "_SelectedValues").val();
                }
                if (result[this.name] !== undefined) {
                    if (this.name.indexOf("Flag_") != 0) {
                        if (!result[this.name].push) {
                            result[this.name] = [result[this.name]];
                        }
                        result[this.name].push(this.value || '');
                    }
                } else {
                    result[this.name] = this.value || '';
                }
            });
            return result;
        },

        searchWithCheckChangesSimple: function () {
            searchPanel.bSearchSimple = true;
            detailPage.checkChanges(false,
                function () {
                    bvDialog.showSearchSavePrompt(
                        function () {
                            detailPage.submit(searchPanel.onSaveSuccessSimple, true);
                        },
                        function () {
                            $("#SearchIgnoreChanges").val("true");
                            searchPanel.searchSimple();
                            $("#SearchIgnoreChanges").val("");
                        }
                    );
                },
                searchPanel.searchSimple
            );
            searchPanel.bSearchSimple = false;
        },
        
        searchWithCheckChanges: function () {
            if (!($("#NotHidePanel").length == 1 && $("#NotHidePanel")[0].checked == true)) {
                searchPanel.toggle();
            }
            detailPage.checkChanges(false,
                function () {
                    bvDialog.showSearchSavePrompt(
                        function () {
                            detailPage.submit(searchPanel.onSaveSuccess, true);
                        },
                        function () {
                            $("#SearchIgnoreChanges").val("true");
                            searchPanel.searchWithSimple();
                            $("#SearchIgnoreChanges").val("");
                        }
                    );
                },
                searchPanel.searchWithSimple
            );
        },

        onSaveSuccessSimple: function (data) {
            formRefresher.updateControls(data);
            searchPanel.searchSimple();
        },
        onSaveSuccess: function (data) {
            formRefresher.updateControls(data);
            searchPanel.searchWithSimple();
        },

        searchSimple: function () {
            var hasError = false;
            if (validatorFacade.validate(validator)) {
                $("#bFirstSearchClick").val("1");
                $("#bSearchClick").val("1");
                gridFacade.reload(searchPanel.defaultGridName);
                $("#bSearchClick").val("0");
            } else {
                hasError = true;
            }
            if (hasError) {
                bvDialog.showError(EIDSS.BvMessages.strSearchPanelMandatoryFields_msgId);
            }
            return false;
        },
        setSimpleClearItems: function () {
            var sslist = $('#SimpleSearchList');
            if (sslist.length > 0) {
                $("#simpleSearchButton")[0].style.visibility = "hidden";
                $(".clsItemControl").each(function() {
                    this.style.visibility = "hidden";
                });

                var dropdownlist = sslist.data().kendoDropDownList;
                dropdownlist.select(0);
            }
        },
        setSimpleEnabledItems: function () {
            var sslist = $('#SimpleSearchList');
            if (sslist.length > 0) {
                var dropdownlist = sslist.data().kendoDropDownList;
                var ssdata = dropdownlist.dataSource.data();
                $.each(ssdata, function () {
                    this.set("Classname", "clsItem");
                });

                var a = $("#panelForm").serializeArray();
                $.each(a, function () {
                    var i = this.name.lastIndexOf("_");
                    if (i > 0) {
                        var name = this.name.substr(i + 1);
                        var isCheckedComboBox = $("#" + this.name + "_SelectedValues").length > 0;
                        if (isCheckedComboBox) {
                            this.value = $("#" + this.name + "_SelectedValues").val();
                        }
                        if (this.value != "" && this.value != "0") {
                            $.each(ssdata, function () {
                                if (this.Value == name) {
                                    this.set("Classname", "clsReadOnlyItem");
                                }
                            });
                        }
                    }
                });
            }
        },
        
        searchWithSimple: function () {
            searchPanel.setSimpleClearItems();
            return searchPanel.searchSimple();
        },
        
        search: function () {
            var hasError = false;
            if (validatorFacade.validate(validator)) {
                if (!($("#NotHidePanel").length == 1 && $("#NotHidePanel")[0].checked == true)) {
                    searchPanel.toggle();
                }
                $("#bFirstSearchClick").val("1");
                $("#bSearchClick").val("1");
                gridFacade.reload(searchPanel.defaultGridName);
                $("#bSearchClick").val("0");
            } else {
                hasError = true;
            }
            if (hasError) {
                bvDialog.showError(EIDSS.BvMessages.strSearchPanelMandatoryFields_msgId);
            }
            return false;
        },

        clearSimple: function () {
            searchPanel.clearByName("simplesearchpanel");
        },

        clear: function () {
            searchPanel.clearByName("searchpanel");
        },

        clearByName: function(name) {
            $("div#" + name + " input[type='text']:not('.readonlyField')").val("");
            $("div#" + name + " input." + commonWidgetsFacade.inputClassName).val("");
            $("div#" + name + " input[type='checkbox'][name!='NotHidePanel']").removeAttr("checked");

            var lookups = $("div#" + name + " [id^='Lookup']");
            var lookupsCount = lookups.length;
            for (var i = 0; i < lookupsCount; i++) {
                var id = lookups[i].id;
                if (id.lastIndexOf("_SelectedValues") > 0) {
                    continue;
                }
                var isCheckedComboBox = $("#" + id + "_SelectedValues").length > 0;
                if (isCheckedComboBox) {
                    clearCheckedComboBox(id);
                } else {
                    comboBoxFacade.setValueById(id, null, true);
                }
            }

            var def;
            var req = $(".requiredField");
            var reqCount = req.length;
            for (i = 0; i < reqCount; i++) {
                var item = req[i];
                def = $("#Default" + item.id).val();
                if (!def) {
                    continue;
                }
                if (item.id.indexOf("Lookup") > -1) {
                    comboBoxFacade.setValueById(item.id, def, true);
                } else if (req[i].id.indexOf('Date') > -1) {
                    datePickerFacade.setValueById(item.id, def);
                }
            }

            twinkleTextBox.showLabels();
        },

        toggle: function() {
            var arrows = $("#spTogglePanel span");
            arrows.toggle();
            $("#searchpanel").toggle();
            twinkleTextBox.showLabels();
        },

        onComboBoxOpen: function (e, width, isDropDown) {
            if (width > 0) {
                var element = e.sender.element[0];
                var id = element.id;
                var combobox = comboBoxFacade.getControlData(id, isDropDown);
                if (combobox.list.width() < width)
                    combobox.list.width(width);
            }
        },

        onCheckedComboBoxChanged: function(e) {
            var args = comboBoxFacade.getOnChangedEventArgs(e, this);
            if (args.selectedIndex != 0) {
                e.preventDefault();
            } else {
                var controlId = args.senderId;
                clearCheckedComboBox(controlId);
            }
        },

        setCheckedCheckBox: function (id, index) {
            var itemsListId = id + "-list";
            var items = $("#" + itemsListId + " ." + comboBoxFacade.itemCheckBoxClassName);

            var item = items[index];
            item.checked = true;

            var checkedItems = comboBoxFacade.getCheckedItems(id);
            var text = checkedItems.texts.toString();
            comboBoxFacade.setTextById(id, text, true);
            $("#" + id + "_SelectedValues").val(checkedItems.values.toString());
            twinkleTextBox.updateDdlLabels(id, text);
        },
        
        bindCheckedComboBoxClickEvent: function (controlId, selectedIndexes) {
            hideEmptyItemInCheckedComboBox();
            clearCheckedComboBox(controlId);
            $("." + comboBoxFacade.itemCheckBoxClassName).bind("click", { controlId: controlId }, function (event) {
                var e = arguments[0];
                onCheckedComboBoxClick(e, event.data.controlId);
            });
            
            if (selectedIndexes.length >= 0) {
                jQuery.each(selectedIndexes.split(","), function (i, index) {
                    if (index.length > 0) {
                        searchPanel.setCheckedCheckBox(controlId, index);
                    }
                });
            }
        },

        onComboboxBound: function(e) {
            var args = comboBoxFacade.getOnBoundEventArgs(e);
            twinkleTextBox.updateDdlLabels(args.senderId, args.selectedText);
        },

        onComboboxChanged: function(e) {
            var args = comboBoxFacade.getOnChangedEventArgs(e, this);
            twinkleTextBox.updateDdlLabels(args.senderId, args.selectedText);
        },
        
        onSimpleSearchOpen: function (e) {
            searchPanel.setSimpleEnabledItems();
        },

        onSimpleSearchChanged: function (e) {

            var args = comboBoxFacade.getOnChangedEventArgs(e, this);

            if (this.dataItem(e.item.index()).Classname == "clsReadOnlyItem") {
                e.preventDefault();
            } else {
                if (args.previousValue != "0" && args.previousValue != "") {
                    searchPanel.clearSimple();
                    $("#simpleSearchButton")[0].style.visibility = "hidden";
                    $("#" + args.previousValue + "_div")[0].style.visibility = "hidden";
                    $("#" + args.previousValue + "_div")[0].style.height = "0px";
                }
                if (args.selectedValue != "0" && args.selectedValue != "") {
                    $("#simpleSearchButton")[0].style.visibility = "visible";
                    $("#" + args.selectedValue + "_div")[0].style.visibility = "visible";
                    $("#" + args.selectedValue + "_div")[0].style.height = "";
                }
            }
        },

        fillDateRange: function (event, range, idfrom, idto) {
            event.preventDefault();
            var date = new Date();
            var datefrom;
            if (range == "month") {
                datefrom = new Date(date.getFullYear(), date.getMonth(), 1);
            } else {
                if (range == "quarter") {
                    var a = date.getMonth();
                    a = a - a % 3;
                    datefrom = new Date(date.getFullYear(), (a / 3) * 3, 1);
                } else {
                    if (range == "year") {
                        datefrom = new Date(date.getFullYear(), 0, 1);
                    }
                }
            }
            datePickerFacade.setValueById(idfrom, datefrom);
            var dateTo = new Date(date.getFullYear(), date.getMonth(), date.getDate());
            datePickerFacade.setValueById(idto, dateTo);

            var controlFrom = $("#" + idfrom);
            var parentFrom = controlFrom.closest(".twinkleInput");
            parentFrom.addClass("populated");

            var controlTo = $("#" + idto);
            var parentTo = controlTo.closest(".twinkleInput");
            parentTo.addClass("populated");
        }
    };
})();
