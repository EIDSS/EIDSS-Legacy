/*
function MyDate() {
    var d = Date.apply(Date, arguments);
    //if ((arguments.length == 3 || arguments.length == 6)
    //    && (arguments[0] < 100 && arguments[0] >= 0)) {
    //    d.setFullYear(arguments[0]);
        return d;
    //}
}
var d = MyDate();

var bind = Function.bind;
var unbind = bind.bind(bind);

var __regExp = /(http(s?):\/\/)/ig;
var __currentLang = null;

function __setLanguage() {
    var lang = document.URL.replace(__regExp, "", "$1");
    lang = lang.substring(lang.indexOf("/") + 1, lang.length);
    __currentLang = lang.substring(0, lang.indexOf("/"));
}

function __getLanguage() {
    if (!__currentLang) {
        __setLanguage();
    }
    return __currentLang;
}

function instantiate(constructor, args) {
    return new (unbind(constructor, null).apply(null, args));
}

function myDate() {
    var date = instantiate(Date, arguments);
    var args = arguments.length;
    var arg = arguments[0];

    //if ((args === 3 || args == 6) && arg < 100 && arg >= 0)
    //    date.setFullYear(arg);
    //if (__getLanguage() == "th-TH") {
    //    if (date.getFullYear() < 2500) {
    //        date.setFullYear(date.getFullYear() + 543);
    //    }
    //}
    return date;
}

Date = function (Date) {
    MyDate.prototype = Date.prototype;

    return MyDate;

    function MyDate() {
        var date = instantiate(Date, arguments);
        //var args = arguments.length;
        //var arg = arguments[0];

        //if ((args === 3 || args == 6) && arg < 100 && arg >= 0)
        //    date.setFullYear(arg);
            
        if (__getLanguage() == "th-TH") {
            if (date.getFullYear() < 2500) {
                //date.setFullYear(date.getFullYear() + 543);
            }
        }
        return date;
    }
}(Date);
*/
