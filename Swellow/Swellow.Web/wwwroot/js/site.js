// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// 功能：页面加载完有多个事件，推荐方案
// 参数：把现有的window.onload事件func处理函数的值存入变量oldOnload
// 原理：如果这个处理函数还没有绑定任何函数，就像平时那样把新函数添加给它
//       如果在这个处理函数上已经绑定了一些函数，就把新函数追加到现有指令的末尾
function addLoadEvent(func) {
    var oldOnload = window.onload;
    if (typeof window.onload != 'function') {
        window.onload = func;
    } else {
        window.onload = function () {
            oldOnload();
            func();
        }
    }
}


// 功能：页面加载完后，设置页面主体的padding-top为导航栏的height，使页面主体内容不会被导航栏遮挡。
// 参数：无
function adjustBodyMain() {
    var heightNavbar = document.getElementById("Home_Navbar").offsetHeight*1.5 + "px";
    document.getElementById("Home_BodyMain").style.paddingTop = heightNavbar;
}


addLoadEvent(adjustBodyMain);