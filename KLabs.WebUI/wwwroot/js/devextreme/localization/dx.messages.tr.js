/*!
* DevExtreme (dx.messages.tr.js)
* Version: 19.2.6
* Build date: Thu Jan 30 2020
*
* Copyright (c) 2012 - 2020 Developer Express Inc. ALL RIGHTS RESERVED
* Read about DevExtreme licensing here: https://js.devexpress.com/Licensing/
*/
"use strict";

! function(root, factory) {
    if ("function" === typeof define && define.amd) {
        define(function(require) {
            factory(require("devextreme/localization"))
        })
    } else {
        if ("object" === typeof module && module.exports) {
            factory(require("devextreme/localization"))
        } else {
            factory(DevExpress.localization)
        }
    }
}(this, function(localization) {
    localization.loadMessages({
        tr: {
            Yes: "Evet",
            No: "Hayir",
            Cancel: "Iptal",
            Clear: "Temizle",
            Done: "Tamam",
            Loading: "Yukleniyor...",
            Select: "Sec...",
            Search: "Ara",
            Back: "Geri",
            OK: "Tamam",
            "dxCollectionWidget-noDataText": "Gosterilecek bilgi yok",
            "validation-required": "Zorunlu",
            "validation-required-formatted": "{0} gerekli",
            "validation-numeric": "Deger bir sayi olmali",
            "validation-numeric-formatted": "{0} bir sayi olmali",
            "validation-range": "Deger aralik disinda",
            "validation-range-formatted": "{0} aralik disinda",
            "validation-stringLength": "Degerin uzunlugu dogru degil",
            "validation-stringLength-formatted": "{0} uzunlugu dogru degil",
            "validation-custom": "Deger gecersiz",
            "validation-custom-formatted": "{0} gecersiz",
            "validation-compare": "Degerler eslesmiyor",
            "validation-compare-formatted": "{0} eslesmiyor",
            "validation-pattern": "Deger kalipla eslesmiyor",
            "validation-pattern-formatted": "{0} kalipla eslesmiyor",
            "validation-email": "E-posta gecersiz",
            "validation-email-formatted": "{0} gecersiz",
            "validation-mask": "Deger gecersiz",
            "dxLookup-searchPlaceholder": "Minimum karakter sayisi: {0}",
            "dxList-pullingDownText": "Yenilemek icin asagiya cekin...",
            "dxList-pulledDownText": "Yenilemek icin birakin...",
            "dxList-refreshingText": "Yenileniyor...",
            "dxList-pageLoadingText": "Yukleniyor...",
            "dxList-nextButtonText": "Daha",
            "dxList-selectAll": "Tumunu Sec",
            "dxListEditDecorator-delete": "Sil",
            "dxListEditDecorator-more": "Daha",
            "dxScrollView-pullingDownText": "Yenilemek icin asagiya cekin...",
            "dxScrollView-pulledDownText": "Yenilemek icin birakin...",
            "dxScrollView-refreshingText": "Yenileniyor...",
            "dxScrollView-reachBottomText": "Yukleniyor...",
            "dxDateBox-simulatedDataPickerTitleTime": "Saat sec",
            "dxDateBox-simulatedDataPickerTitleDate": "Tarih sec",
            "dxDateBox-simulatedDataPickerTitleDateTime": "Tarih ve saati secin",
            "dxDateBox-validation-datetime": "Deger bir tarih veya saat olmalidir",
            "dxFileUploader-selectFile": "Dosya sec",
            "dxFileUploader-dropFile": "veya Dosyayi buraya birakin",
            "dxFileUploader-bytes": "bytes",
            "dxFileUploader-kb": "kb",
            "dxFileUploader-Mb": "Mb",
            "dxFileUploader-Gb": "Gb",
            "dxFileUploader-upload": "Yukleme",
            "dxFileUploader-uploaded": "Yuklenen",
            "dxFileUploader-readyToUpload": "Yuklemeye hazir",
            "dxFileUploader-uploadFailedMessage": "Yukleme basarisiz",
            "dxFileUploader-invalidFileExtension": "Dosya turune izin verilmiyor",
            "dxFileUploader-invalidMaxFileSize": "Dosya cok buyuk",
            "dxFileUploader-invalidMinFileSize": "Dosya cok kucuk",
            "dxRangeSlider-ariaFrom": "Itibaren",
            "dxRangeSlider-ariaTill": "Kadar",
            "dxSwitch-switchedOnText": "Acik",
            "dxSwitch-switchedOffText": "Kapali",
            "dxForm-optionalMark": "istege bagli",
            "dxForm-requiredMessage": "{0} gerekli",
            "dxNumberBox-invalidValueMessage": "Deger bir sayi olmali",
            "dxNumberBox-noDataText": "Veri yok",
            "dxDataGrid-columnChooserTitle": "Sutun Secici",
            "dxDataGrid-columnChooserEmptyText": "Sutunu gizlemek icin buraya surukleyin",
            "dxDataGrid-groupContinuesMessage": "Bir sonraki sayfada devam ediyor",
            "dxDataGrid-groupContinuedMessage": "Onceki sayfadan devam",
            "dxDataGrid-groupHeaderText": "Bu Sutuna Gore Grupla",
            "dxDataGrid-ungroupHeaderText": "Grubu Kaldir",
            "dxDataGrid-ungroupAllText": "Tum Gruplari Kaldir",
            "dxDataGrid-editingEditRow": "Duzenle",
            "dxDataGrid-editingSaveRowChanges": "Kaydet",
            "dxDataGrid-editingCancelRowChanges": "Iptal",
            "dxDataGrid-editingDeleteRow": "Sil",
            "dxDataGrid-editingUndeleteRow": "Silme",
            "dxDataGrid-editingConfirmDeleteMessage": "Bu kaydi silmek istediginize emin misiniz?",
            "dxDataGrid-validationCancelChanges": "Degisiklikleri iptal et",
            "dxDataGrid-groupPanelEmptyText": "Bu sutuna gore gruplamak icin bir sutun basligini buraya surukleyin",
            "dxDataGrid-noDataText": "Veri yok",
            "dxDataGrid-searchPanelPlaceholder": "Arama...",
            "dxDataGrid-filterRowShowAllText": "(Tumu)",
            "dxDataGrid-filterRowResetOperationText": "Sifirla",
            "dxDataGrid-filterRowOperationEquals": "Esittir",
            "dxDataGrid-filterRowOperationNotEquals": "Esit degil",
            "dxDataGrid-filterRowOperationLess": "Daha kucuk",
            "dxDataGrid-filterRowOperationLessOrEquals": "Daha kucuk veya esit",
            "dxDataGrid-filterRowOperationGreater": "Daha buyuk",
            "dxDataGrid-filterRowOperationGreaterOrEquals": "Daha buyuk veya esit",
            "dxDataGrid-filterRowOperationStartsWith": "Ile baslar",
            "dxDataGrid-filterRowOperationContains": "Iceren",
            "dxDataGrid-filterRowOperationNotContains": "Icermeyen",
            "dxDataGrid-filterRowOperationEndsWith": "Ile biten",
            "dxDataGrid-filterRowOperationBetween": "Arasinda",
            "dxDataGrid-filterRowOperationBetweenStartText": "Basla",
            "dxDataGrid-filterRowOperationBetweenEndText": "Bitis",
            "dxDataGrid-applyFilterText": "Filtre uygula",
            "dxDataGrid-trueText": "evet",
            "dxDataGrid-falseText": "hayir",
            "dxDataGrid-sortingAscendingText": "Artan Siralama",
            "dxDataGrid-sortingDescendingText": "Azalan Siralama",
            "dxDataGrid-sortingClearText": "Siralamayi Temizle",
            "dxDataGrid-editingSaveAllChanges": "Degisiklikleri Kaydet",
            "dxDataGrid-editingCancelAllChanges": "Degisiklikleri iptal et",
            "dxDataGrid-editingAddRow": "Satir ekle",
            "dxDataGrid-summaryMin": "Min: {0}",
            "dxDataGrid-summaryMinOtherColumn": "{1} min: {0}",
            "dxDataGrid-summaryMax": "Max: {0}",
            "dxDataGrid-summaryMaxOtherColumn": "{1} max: {0}",
            "dxDataGrid-summaryAvg": "Ort: {0}",
            "dxDataGrid-summaryAvgOtherColumn": "{1} ortalamasi: {0}",
            "dxDataGrid-summarySum": "Top: {0}",
            "dxDataGrid-summarySumOtherColumn": "{1} toplami: {0}",
            "dxDataGrid-summaryCount": "Toplam: {0}",
            "dxDataGrid-columnFixingFix": "Sabitle",
            "dxDataGrid-columnFixingUnfix": "coz",
            "dxDataGrid-columnFixingLeftPosition": "Sola",
            "dxDataGrid-columnFixingRightPosition": "Saga",
            "dxDataGrid-exportTo": "Disa aktar",
            "dxDataGrid-exportToExcel": "Excel dosyasina aktar",
            "dxDataGrid-exporting": "Disa Aktar...",
            "dxDataGrid-excelFormat": "Excel dosyasi",
            "dxDataGrid-selectedRows": "Secili satirlar",
            "dxDataGrid-exportSelectedRows": "Secili satirlari aktar",
            "dxDataGrid-exportAll": "Tum verileri disa aktar",
            "dxDataGrid-headerFilterEmptyValue": "(Blanks)",
            "dxDataGrid-headerFilterOK": "Tamam",
            "dxDataGrid-headerFilterCancel": "Iptal",
            "dxDataGrid-ariaColumn": "Sutun",
            "dxDataGrid-ariaValue": "Veri",
            "dxDataGrid-ariaFilterCell": "Filtre hucresi",
            "dxDataGrid-ariaCollapse": "Daralt",
            "dxDataGrid-ariaExpand": "Genislet",
            "dxDataGrid-ariaDataGrid": "Tablo",
            "dxDataGrid-ariaSearchInGrid": "Tabloda ara",
            "dxDataGrid-ariaSelectAll": "Hepsini sec",
            "dxDataGrid-ariaSelectRow": "Satiri sec",
            "dxDataGrid-filterBuilderPopupTitle": "Filtre Olusturucu",
            "dxDataGrid-filterPanelCreateFilter": "Filtre Olustur",
            "dxDataGrid-filterPanelClearFilter": "Temizle",
            "dxDataGrid-filterPanelFilterEnabledHint": "Filtreyi etkinlestir",
            "dxTreeList-ariaTreeList": "Agac listesi",
            "dxTreeList-editingAddRowToNode": "Ekle",
            "dxPager-infoText": "Sayfa {0} / {1} ({2} veri)",
            "dxPager-pagesCountText": "arasinda",
            "dxPivotGrid-grandTotal": "Genel Toplam",
            "dxPivotGrid-total": "{0} Toplam",
            "dxPivotGrid-fieldChooserTitle": "Alan Secici",
            "dxPivotGrid-showFieldChooser": "Alan Seciciyi Goster",
            "dxPivotGrid-expandAll": "Tumunu Genislet",
            "dxPivotGrid-collapseAll": "Tumunu Daralt",
            "dxPivotGrid-sortColumnBySummary": '"{0}" Bu Sutuna Gore Sirala',
            "dxPivotGrid-sortRowBySummary": '"{0}" Bu Satira Gore Sirala',
            "dxPivotGrid-removeAllSorting": "Tum Siralamalari Kaldir",
            "dxPivotGrid-dataNotAvailable": "N/A",
            "dxPivotGrid-rowFields": "Satir Alanlari",
            "dxPivotGrid-columnFields": "Sutun Alanlari",
            "dxPivotGrid-dataFields": "Veri Alanlari",
            "dxPivotGrid-filterFields": "Filtre Alanlari",
            "dxPivotGrid-allFields": "Tum Alanlar",
            "dxPivotGrid-columnFieldArea": "Sutun Alanlarini Buraya Birak",
            "dxPivotGrid-dataFieldArea": "Veri Alanlarini Buraya Birak",
            "dxPivotGrid-rowFieldArea": "Satir Alanlarini Buraya Birak",
            "dxPivotGrid-filterFieldArea": "Filtre Alanlarini Buraya Birak",
            "dxScheduler-editorLabelTitle": "Konu",
            "dxScheduler-editorLabelStartDate": "Baslangic Tarihi",
            "dxScheduler-editorLabelEndDate": "Bitis Tarihi",
            "dxScheduler-editorLabelDescription": "Aciklama",
            "dxScheduler-editorLabelRecurrence": "Tekrar",
            "dxScheduler-openAppointment": "Randevu Ac",
            "dxScheduler-recurrenceNever": "Asla",
            "dxScheduler-recurrenceDaily": "Gunluk",
            "dxScheduler-recurrenceWeekly": "Haftalik",
            "dxScheduler-recurrenceMonthly": "Aylik",
            "dxScheduler-recurrenceYearly": "Yillik",
            "dxScheduler-recurrenceRepeatEvery": "Her tekrarla",
            "dxScheduler-recurrenceRepeatOn": "Tekrarla",
            "dxScheduler-recurrenceEnd": "Tekrari bitir",
            "dxScheduler-recurrenceAfter": "Sonra",
            "dxScheduler-recurrenceOn": "Ile",
            "dxScheduler-recurrenceRepeatDaily": "gunler",
            "dxScheduler-recurrenceRepeatWeekly": "haftalar",
            "dxScheduler-recurrenceRepeatMonthly": "aylar",
            "dxScheduler-recurrenceRepeatYearly": "yillar",
            "dxScheduler-switcherDay": "Gun",
            "dxScheduler-switcherWeek": "Hafta",
            "dxScheduler-switcherWorkWeek": "calisma Haftasi",
            "dxScheduler-switcherMonth": "Ay",
            "dxScheduler-switcherAgenda": "Ajanda",
            "dxScheduler-switcherTimelineDay": "Zaman cizelgesi Gunu",
            "dxScheduler-switcherTimelineWeek": "Zaman cizelgesi Haftasi",
            "dxScheduler-switcherTimelineWorkWeek": "Zaman cizelgesi calisma Haftasi",
            "dxScheduler-switcherTimelineMonth": "TZaman cizelgesi calisma Ayi",
            "dxScheduler-recurrenceRepeatOnDate": "tarihinde",
            "dxScheduler-recurrenceRepeatCount": "olaylar",
            "dxScheduler-allDay": "Tum gun",
            "dxScheduler-confirmRecurrenceEditMessage":
                "Yalnizca bu randevuyu veya tum diziyi duzenlemek ister misiniz?",
            "dxScheduler-confirmRecurrenceDeleteMessage":
                "Yalnizca bu randevuyu veya tum diziyi silmek istiyor musunuz?",
            "dxScheduler-confirmRecurrenceEditSeries": "Serileri duzenle",
            "dxScheduler-confirmRecurrenceDeleteSeries": "Serileri sil",
            "dxScheduler-confirmRecurrenceEditOccurrence": "Randevuyu duzenle",
            "dxScheduler-confirmRecurrenceDeleteOccurrence": "Randevuyu sil",
            "dxScheduler-noTimezoneTitle": "Saat dilimi yok",
            "dxScheduler-moreAppointments": "{0} daha",
            "dxCalendar-todayButtonText": "Bugun",
            "dxCalendar-ariaWidgetName": "Takvim",
            "dxColorView-ariaRed": "Kirmizi",
            "dxColorView-ariaGreen": "Yesil",
            "dxColorView-ariaBlue": "Mavi",
            "dxColorView-ariaAlpha": "�effaflik",
            "dxColorView-ariaHex": "Renk kodu",
            "dxTagBox-selected": "{0} secili",
            "dxTagBox-allSelected": "Tumu secildi ({0})",
            "dxTagBox-moreSelected": "{0} daha",
            "vizExport-printingButtonText": "Yazdir",
            "vizExport-titleMenuText": "Disa Aktar/Yazdir",
            "vizExport-exportButtonText": "{0} dosya",
            "dxFilterBuilder-and": "Ve",
            "dxFilterBuilder-or": "Veya",
            "dxFilterBuilder-notAnd": "Degil Ve",
            "dxFilterBuilder-notOr": "Degil Veya",
            "dxFilterBuilder-addCondition": "Kosul Ekle",
            "dxFilterBuilder-addGroup": "Grup Ekle",
            "dxFilterBuilder-enterValueText": "<deger gir>",
            "dxFilterBuilder-filterOperationEquals": "Esit",
            "dxFilterBuilder-filterOperationNotEquals": "Esit degil",
            "dxFilterBuilder-filterOperationLess": "Daha kucuk",
            "dxFilterBuilder-filterOperationLessOrEquals": "Daha kucuk veya esit",
            "dxFilterBuilder-filterOperationGreater": "Daha buyuk",
            "dxFilterBuilder-filterOperationGreaterOrEquals": "Daha buyuk veya esit",
            "dxFilterBuilder-filterOperationStartsWith": "Ile baslar",
            "dxFilterBuilder-filterOperationContains": "Icerir",
            "dxFilterBuilder-filterOperationNotContains": "Icermez",
            "dxFilterBuilder-filterOperationEndsWith": "Ile biter",
            "dxFilterBuilder-filterOperationIsBlank": "Bos",
            "dxFilterBuilder-filterOperationIsNotBlank": "Bos degil",
            "dxFilterBuilder-filterOperationBetween": "Arasinda",
            "dxFilterBuilder-filterOperationAnyOf": "Herhangi biri",
            "dxFilterBuilder-filterOperationNoneOf": "Hicbiri",
            "dxHtmlEditor-dialogColorCaption": "Yazi Tipi Rengini Degistir",
            "dxHtmlEditor-dialogBackgroundCaption": "Arka Plan Rengini Degistir",
            "dxHtmlEditor-dialogLinkCaption": "Link Ekle",
            "dxHtmlEditor-dialogLinkUrlField": "URL",
            "dxHtmlEditor-dialogLinkTextField": "Metin",
            "dxHtmlEditor-dialogLinkTargetField": "Linki yeni pencerede ac",
            "dxHtmlEditor-dialogImageCaption": "Resim Ekle",
            "dxHtmlEditor-dialogImageUrlField": "URL",
            "dxHtmlEditor-dialogImageAltField": "Alternatif metin",
            "dxHtmlEditor-dialogImageWidthField": "Genislik (px)",
            "dxHtmlEditor-dialogImageHeightField": "Yukseklik (px)",
            "dxHtmlEditor-heading": "Baslik",
            "dxHtmlEditor-normalText": "Normal metin",
            "dxFileManager-errorNoAccess": "Erisim reddedildi. Islem tamamlanamiyor.",
            "dxFileManager-errorDirectoryExistsFormat": "Klasor '{0}' zaten var.",
            "dxFileManager-errorFileExistsFormat": "Dosya '{0}' zaten var.",
            "dxFileManager-errorFileNotFoundFormat": "Dosya '{0}' bulunamadi",
            "dxFileManager-errorDefault": "Belirtilmemis hata.",
            "dxFileManager-newDirectoryName": "TODO",
            "dxFileManager-rootDirectoryName": "TODO",
            "dxFileManager-errorDirectoryNotFoundFormat": "TODO",
            "dxFileManager-errorWrongFileExtension": "TODO",
            "dxFileManager-errorMaxFileSizeExceeded": "TODO",
            "dxFileManager-errorInvalidSymbols": "TODO",
            "dxDiagram-categoryGeneral": "TODO",
            "dxDiagram-categoryFlowchart": "TODO",
            "dxDiagram-categoryOrgChart": "TODO",
            "dxDiagram-categoryContainers": "TODO",
            "dxDiagram-categoryCustom": "TODO",
            "dxDiagram-commandProperties": "TODO",
            "dxDiagram-commandExport": "TODO",
            "dxDiagram-commandExportToSvg": "TODO",
            "dxDiagram-commandExportToPng": "TODO",
            "dxDiagram-commandExportToJpg": "TODO",
            "dxDiagram-commandUndo": "TODO",
            "dxDiagram-commandRedo": "TODO",
            "dxDiagram-commandFontName": "TODO",
            "dxDiagram-commandFontSize": "TODO",
            "dxDiagram-commandBold": "TODO",
            "dxDiagram-commandItalic": "TODO",
            "dxDiagram-commandUnderline": "TODO",
            "dxDiagram-commandTextColor": "TODO",
            "dxDiagram-commandLineColor": "TODO",
            "dxDiagram-commandFillColor": "TODO",
            "dxDiagram-commandAlignLeft": "TODO",
            "dxDiagram-commandAlignCenter": "TODO",
            "dxDiagram-commandAlignRight": "TODO",
            "dxDiagram-commandConnectorLineType": "TODO",
            "dxDiagram-commandConnectorLineStraight": "TODO",
            "dxDiagram-commandConnectorLineOrthogonal": "TODO",
            "dxDiagram-commandConnectorLineStart": "TODO",
            "dxDiagram-commandConnectorLineEnd": "TODO",
            "dxDiagram-commandConnectorLineNone": "TODO",
            "dxDiagram-commandConnectorLineArrow": "TODO",
            "dxDiagram-commandAutoLayout": "TODO",
            "dxDiagram-commandAutoLayoutTree": "TODO",
            "dxDiagram-commandAutoLayoutLayered": "TODO",
            "dxDiagram-commandAutoLayoutHorizontal": "TODO",
            "dxDiagram-commandAutoLayoutVertical": "TODO",
            "dxDiagram-commandFullscreen": "TODO",
            "dxDiagram-commandUnits": "TODO",
            "dxDiagram-commandPageSize": "TODO",
            "dxDiagram-commandPageOrientation": "TODO",
            "dxDiagram-commandPageOrientationLandscape": "TODO",
            "dxDiagram-commandPageOrientationPortrait": "TODO",
            "dxDiagram-commandPageColor": "TODO",
            "dxDiagram-commandShowGrid": "TODO",
            "dxDiagram-commandSnapToGrid": "TODO",
            "dxDiagram-commandGridSize": "TODO",
            "dxDiagram-commandZoomLevel": "TODO",
            "dxDiagram-commandAutoZoom": "TODO",
            "dxDiagram-commandSimpleView": "TODO",
            "dxDiagram-commandCut": "TODO",
            "dxDiagram-commandCopy": "TODO",
            "dxDiagram-commandPaste": "TODO",
            "dxDiagram-commandSelectAll": "TODO",
            "dxDiagram-commandDelete": "TODO",
            "dxDiagram-commandBringToFront": "TODO",
            "dxDiagram-commandSendToBack": "TODO",
            "dxDiagram-commandLock": "TODO",
            "dxDiagram-commandUnlock": "TODO",
            "dxDiagram-commandInsertShapeImage": "TODO",
            "dxDiagram-commandEditShapeImage": "TODO",
            "dxDiagram-commandDeleteShapeImage": "TODO",
            "dxDiagram-unitIn": "TODO",
            "dxDiagram-unitCm": "TODO",
            "dxDiagram-unitPx": "TODO",
            "dxDiagram-dialogButtonOK": "TODO",
            "dxDiagram-dialogButtonCancel": "TODO",
            "dxDiagram-dialogInsertShapeImageTitle": "TODO",
            "dxDiagram-dialogEditShapeImageTitle": "TODO",
            "dxDiagram-dialogEditShapeImageSelectButton": "TODO",
            "dxDiagram-dialogEditShapeImageLabelText": "TODO"
        }
    });
    
});
DevExpress.localization.locale("tr")