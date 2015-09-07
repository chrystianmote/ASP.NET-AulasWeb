/* begin Page */
var smEventHelper = {
	'bind': function(obj, evt, fn) {
		if (obj.addEventListener)
			obj.addEventListener(evt, fn, false);
		else if (obj.attachEvent)
			obj.attachEvent('on' + evt, fn);
		else
			obj['on' + evt] = fn;
	}
};

var smUserAgent = navigator.userAgent.toLowerCase();

var smBrowser = {
	version: (smUserAgent.match(/.+(?:rv|it|ra|ie)[\/: ]([\d.]+)/) || [])[1],
	safari: /webkit/.test(smUserAgent) && !/chrome/.test(smUserAgent),
	chrome: /chrome/.test(smUserAgent),
	opera: /opera/.test(smUserAgent),
	msie: /msie/.test(smUserAgent) && !/opera/.test(smUserAgent),
	mozilla: /mozilla/.test(smUserAgent) && !/(compatible|webkit)/.test(smUserAgent)
};
 
smCssHelper = function() {
    var is = function(t) { return (smUserAgent.indexOf(t) != -1) };
    var el = document.getElementsByTagName('html')[0];
    var val = [(!(/opera|webtv/i.test(smUserAgent)) && /msie (\d)/.test(smUserAgent)) ? ('ie ie' + RegExp.$1)
    : is('firefox/2') ? 'gecko firefox2'
    : is('firefox/3') ? 'gecko firefox3'
    : is('gecko/') ? 'gecko'
    : is('chrome/') ? 'chrome'
    : is('opera/9') ? 'opera opera9' : /opera (\d)/.test(smUserAgent) ? 'opera opera' + RegExp.$1
    : is('konqueror') ? 'konqueror'
    : is('applewebkit/') ? 'webkit safari'
    : is('mozilla/') ? 'gecko' : '',
    (is('x11') || is('linux')) ? ' linux'
    : is('mac') ? ' mac'
    : is('win') ? ' win' : ''
    ].join(' ');
    if (!el.className) {
     el.className = val;
    } else {
     var newCl = el.className;
     newCl += (' ' + val);
     el.className = newCl;
    }
} ();

(function() {
    // fix ie blinking
    var m = document.uniqueID && document.compatMode && !window.XMLHttpRequest && document.execCommand;
    try { if (!!m) { m('BackgroundImageCache', false, true); } }
    catch (oh) { };
})();

var smLoadEvent = (function() {
	var list = [];

	var done = false;
	var ready = function() {
		if (done) return;
		done = true;
		for (var i = 0; i < list.length; i++)
			list[i]();
	};

	if (document.addEventListener && !smBrowser.opera)
		document.addEventListener('DOMContentLoaded', ready, false);

	if (smBrowser.msie && window == top) {
		(function() {
			try {
				document.documentElement.doScroll('left');
			} catch (e) {
				setTimeout(arguments.callee, 10);
				return;
			}
			ready();
		})();
	}

	if (smBrowser.opera) {
		document.addEventListener('DOMContentLoaded', function() {
			for (var i = 0; i < document.styleSheets.length; i++) {
				if (document.styleSheets[i].disabled) {
					setTimeout(arguments.callee, 10);
					return;
				}
			}
			ready();
		}, false);
	}

	if (smBrowser.safari || smBrowser.chrome) {
		var numStyles;
		(function() {
			if (document.readyState != 'loaded' && document.readyState != 'complete') {
				setTimeout(arguments.callee, 10);
				return;
			}
			if ('undefined' == typeof numStyles) {
				numStyles = document.getElementsByTagName('style').length;
				var links = document.getElementsByTagName('link');
				for (var i = 0; i < links.length; i++) {
					numStyles += (links[i].getAttribute('rel') == 'stylesheet') ? 1 : 0;
				}
				if (document.styleSheets.length != numStyles) {
					setTimeout(arguments.callee, 0);
					return;
				}
			}
			ready();
		})();
	}
	smEventHelper.bind(window, 'load', ready);
	return ({
		add: function(f) {
			list.push(f);
		}
	})
})();


function smGetElementsByClassName(clsName, parentEle, tagName) {
	var elements = null;
	var found = [];
	var s = String.fromCharCode(92);
	var re = new RegExp('(?:^|' + s + 's+)' + clsName + '(?:$|' + s + 's+)');
	if (!parentEle) parentEle = document;
	if (!tagName) tagName = '*';
	elements = parentEle.getElementsByTagName(tagName);
	if (elements) {
		for (var i = 0; i < elements.length; ++i) {
			if (elements[i].className.search(re) != -1) {
				found[found.length] = elements[i];
			}
		}
	}
	return found;
}

var _smStyleUrlCached = null;
function smGetStyleUrl() {
    if (null == _smStyleUrlCached) {
        var ns;
        _smStyleUrlCached = '';
        ns = document.getElementsByTagName('link');
        for (var i = 0; i < ns.length; i++) {
            var l = ns[i];
            if (l.href && /style\.ie6\.css(\?.*)?$/.test(l.href)) {
                return _smStyleUrlCached = l.href.replace(/style\.ie6\.css(\?.*)?$/, '');
            }
        }

        ns = document.getElementsByTagName('style');
        for (var i = 0; i < ns.length; i++) {
            var matches = new RegExp('import\\s+"([^"]+\\/)style\\.ie6\\.css"').exec(ns[i].innerHTML);
            if (null != matches && matches.length > 0)
                return _smStyleUrlCached = matches[1];
        }
    }
    return _smStyleUrlCached;
}

function smFixPNG(element) {
	if (smBrowser.msie && smBrowser.version < 7) {
		var src;
		if (element.tagName == 'IMG') {
			if (/\.png$/.test(element.src)) {
				src = element.src;
				element.src = smGetStyleUrl() + 'images/spacer.gif';
			}
		}
		else {
			src = element.currentStyle.backgroundImage.match(/url\("(.+\.png)"\)/i);
			if (src) {
				src = src[1];
				element.runtimeStyle.backgroundImage = 'none';
			}
		}
		if (src) element.runtimeStyle.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(src='" + src + "')";
	}
}

function smHasClass(el, cls) {
	return (el && el.className && (' ' + el.className + ' ').indexOf(' ' + cls + ' ') != -1);
}
/* end Page */

/* begin Layout */
function smLayoutIESetup() {
    var isIE = navigator.userAgent.toLowerCase().indexOf("msie") != -1;
    if (!isIE) return;
    var q = smGetElementsByClassName("sm-content-layout", document, "div");
    if (!q || !q.length) return;
    for (var i = 0; i < q.length; i++) {
        var l = q[i];
        var l_childs = l.childNodes;
        var r = null;
        for (var p = 0; p < l_childs.length; p++) {
            var l_ch = l_childs[p];
            if ((String(l_ch.tagName).toLowerCase() == "div") && smHasClass(l_ch, "sm-content-layout-row")) {
                r = l_ch;
                break;
            }
        }
        if (!r) continue;
        var c = [];
        var r_childs = r.childNodes;
        for (var o = 0; o < r_childs.length; o++) {
            var r_ch = r_childs[o];
            if ((String(r_ch.tagName).toLowerCase() == "div") && smHasClass(r_ch, "sm-layout-cell")) {
                c.push(r_ch);
            }
        }
        if (!c || !c.length) continue;
        var table = document.createElement("table");
        table.className = l.className;
        var row = table.insertRow(-1);
        table.className = l.className;
        for (var j = 0; j < c.length; j++) {
            var cell = row.insertCell(-1);
            var s = c[j];
            cell.className = s.className;
            while (s.firstChild) {
                cell.appendChild(s.firstChild);
            }
        }
        l.parentNode.insertBefore(table, l);
        l.parentNode.removeChild(l);
    }
}
smLoadEvent.add(smLayoutIESetup);
/* end Layout */

/* begin VMenu */
function smAddVMenuSeparators() {
    var create_VSeparator = function(sub, first) {
        var cls = 'sm-v' + (sub ? "sub" : "") + 'menu-separator';
        var li = document.createElement('li');
        li.className = (first ? (cls + " " + cls + " sm-vmenu-separator-first") : cls);
        var span = document.createElement('span');
        span.className = cls+'-span';
        li.appendChild(span);
        return li;
    };
	var menus = smGetElementsByClassName("sm-vmenublock", document, "div");
	for (var k = 0; k < menus.length; k++) {
		var uls = menus[k].getElementsByTagName("ul");
		for (var i = 0; i < uls.length; i++) {
			var ul = uls[i];
			var childs = ul.childNodes;
			var listItems = [];
			for (var y = 0; y < childs.length; y++) {
				var el = childs[y];
				if (String(el.tagName).toLowerCase() == "li") listItems.push(el);
            }
    		for (var j = 0; j < listItems.length; j++) {
			    var item = listItems[j];
			    if ((item.parentNode.getElementsByTagName("li")[0] == item) && (item.parentNode != uls[0]))
			        item.parentNode.insertBefore(create_VSeparator(item.parentNode.parentNode.parentNode != uls[0], true), item);
			    if (j < listItems.length - 1)
			        item.parentNode.insertBefore(create_VSeparator(item.parentNode != uls[0], false), item.nextSibling);
			}
		}
	}
}
smLoadEvent.add(smAddVMenuSeparators);

/* end VMenu */

/* begin VMenuItem */
function smVMenu() {
    var menus = smGetElementsByClassName("sm-vmenu", document, "ul");
    for (var k = 0; k < menus.length; k++) {
        var vmenu = menus[k];
        vmenu.uls = vmenu.getElementsByTagName("ul");
        vmenu.items = vmenu.getElementsByTagName("li");
        vmenu.alinks = vmenu.getElementsByTagName("a");
        
        for (var x = 0; x < vmenu.items.length; x++) {
            var li = vmenu.items[x];
            li.className = li.className.replace(/active/, "").replace("  ", " ");
            for (var s = 0; s < li.childNodes.length; s++) {
                var ch = li.childNodes[s];
                if (!(ch && ch.tagName)) continue;
                if (String(ch.tagName).toLowerCase() == "a") {
                    if (ch.href == window.location.href)
                       vmenu.active = li;
                    li.a = ch;
                }
                if (String(ch.tagName).toLowerCase() == "ul") 
                    li.ul = ch;
                ch.className = ch.className.replace(/active/, "").replace("  ", " ");
            }
        }
        if (!vmenu.active) return;
        if (vmenu.active.ul) vmenu.active.ul.className += " active";
        var parent = vmenu.active;
        while (parent && parent != vmenu) {
            parent.className += " active";
            if (parent.a) parent.a.className += " active";
            parent = parent.parentNode;
        }
    }
}

smLoadEvent.add(smVMenu);
/* end VMenuItem */

/* begin Button */

function smButtonsSetupJsHover(className) {
	var tags = ["input", "a", "button"];
	for (var j = 0; j < tags.length; j++){
		var buttons = smGetElementsByClassName(className, document, tags[j]);
		for (var i = 0; i < buttons.length; i++) {
			var button = buttons[i];
			if (!button.tagName || !button.parentNode) return;
			if (!smHasClass(button.parentNode, 'sm-button-wrapper')) {
				if (!smHasClass(button, 'sm-button')) button.className += ' sm-button';
				var wrapper = document.createElement('span');
				wrapper.className = "sm-button-wrapper";
				if (smHasClass(button, 'active')) wrapper.className += ' active';
				var spanL = document.createElement('span');
				spanL.className = "l";
				spanL.innerHTML = " ";
				wrapper.appendChild(spanL);
				var spanR = document.createElement('span');
				spanR.className = "r";
				spanR.innerHTML = " ";
				wrapper.appendChild(spanR);
				button.parentNode.insertBefore(wrapper, button);
				wrapper.appendChild(button);
			}
			smEventHelper.bind(button, 'mouseover', function(e) {
				e = e || window.event;
				wrapper = (e.target || e.srcElement).parentNode;
				wrapper.className += " hover";
			});
			smEventHelper.bind(button, 'mouseout', function(e) {
				e = e || window.event;
				button = e.target || e.srcElement;
				wrapper = button.parentNode;
				wrapper.className = wrapper.className.replace(/hover/, "");
				if (!smHasClass(button, 'active')) wrapper.className = wrapper.className.replace(/active/, "");
			});
			smEventHelper.bind(button, 'mousedown', function(e) {
				e = e || window.event;
				button = e.target || e.srcElement;
				wrapper = button.parentNode;
				if (!smHasClass(button, 'active')) wrapper.className += " active";
			});
			smEventHelper.bind(button, 'mouseup', function(e) {
				e = e || window.event;
				button = e.target || e.srcElement;
				wrapper = button.parentNode;
				if (!smHasClass(button, 'active')) wrapper.className = wrapper.className.replace(/active/, "");
			});
		}
	}
}

smLoadEvent.add(function() { smButtonsSetupJsHover("sm-button"); });
/* end Button */


