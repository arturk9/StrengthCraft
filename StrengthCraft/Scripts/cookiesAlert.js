(function (factory) {
    if (typeof define === 'function' && define.amd) {
        define(['jquery'], factory);
    } else {
        factory(jQuery);
    }
}(function ($) {

    var pluses = /\+/g;

    function raw(s) {
        return s;
    }

    function decoded(s) {
        return decodeURIComponent(s.replace(pluses, ' '));
    }

    function converted(s) {
        if (s.indexOf('"') === 0) {
            s = s.slice(1, -1).replace(/\\"/g, '"').replace(/\\\\/g, '\\');
        }
        try {
            return config.json ? JSON.parse(s) : s;
        } catch (er) { }
    }

    var config = $.cookie = function (key, value, options) {

        if (value !== undefined) {
            options = $.extend({}, config.defaults, options);

            if (typeof options.expires === 'number') {
                var days = options.expires, t = options.expires = new Date();
                t.setDate(t.getDate() + days);
            }

            value = config.json ? JSON.stringify(value) : String(value);

            return (document.cookie = [
				config.raw ? key : encodeURIComponent(key),
				'=',
				config.raw ? value : encodeURIComponent(value),
				options.expires ? '; expires=' + options.expires.toUTCString() : '',
				options.path ? '; path=' + options.path : '',
				options.domain ? '; domain=' + options.domain : '',
				options.secure ? '; secure' : ''
            ].join(''));
        }

        // read
        var decode = config.raw ? raw : decoded;
        var cookies = document.cookie.split('; ');
        var result = key ? undefined : {};
        for (var i = 0, l = cookies.length; i < l; i++) {
            var parts = cookies[i].split('=');
            var name = decode(parts.shift());
            var cookie = decode(parts.join('='));

            if (key && key === name) {
                result = converted(cookie);
                break;
            }

            if (!key) {
                result[name] = converted(cookie);
            }
        }

        return result;
    };

    config.defaults = {};

    $.removeCookie = function (key, options) {
        if ($.cookie(key) !== undefined) {
            // Must not alter options, thus extending a fresh object...
            $.cookie(key, '', $.extend({}, options, { expires: -1 }));
            return true;
        }
        return false;
    };

}));

(function ($) {
    $.fn.cookiepolicy = function (options) {
        new jQuery.cookiepolicy($(this), options);
        return this;
    };

    $.cookiepolicy = function (options) {
        options = $.extend({
            cookie: 'cookiepolicyinfo',
            info: 'Używamy ciasteczek. Jeżeli klikniesz <strong>Zamknij</strong>, to będzie oznaczać zgodę na dalsze ich używanie. Też nie mam pojęcia czemu to jest ważne. Pewnie i tego nie przeczytasz ;).',
            close: 'Zamknij'
        }, options || {});

        if ($.cookie(options.cookie) != 'true') {
            var wrapper = $('<div/>').addClass('cookiepolicy').appendTo('body');
            $('<span/>').html(options.info).appendTo(wrapper);
            $('<a/>').addClass('button').html(options.close).appendTo(wrapper)
                .on('click', function (e) {
                    e.preventDefault();
                    $.cookie(options.cookie, true);
                    $(this).parents('.cookiepolicy').remove();
                });
        }
    };
})(jQuery);

$(document).ready(function () {
    $.cookiepolicy();
});