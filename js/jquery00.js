/**
 * Plugin: jquery.zRSSFeed
 * 
 * Version: 1.0.1
 * (c) Copyright 2010, Zazar Ltd
 * 
 * Description: jQuery plugin for display of RSS feeds via Google Feed API
 *              (Based on original plugin jGFeed by jQuery HowTo)
 * 
 * History:
 * 1.0.1 - Corrected issue with multiple instances
 *
 **/

/// <reference path="jquery-1.4.2.min.js" />

  
(function ($) {

    var current = null;

    $.fn.rssfeed = function (rssUrl, options) {

        // Set pluign defaults
        var defaults = {
            limit: 10,
            header: true,
            titletag: 'h4',
            date: true,
            content: true,
            snippet: true,
            showerror: true,
            errormsg: '',
            key: null
        };
        var options = $.extend(defaults, options);

        // Functions
        return this.each(function (i, e) {
            var $e = $(e);

            // Add feed class to user div
            if (!$e.hasClass('rssFeed')) $e.addClass('rssFeed');

            // Check for valid url
            //if (rss_fields[rssId] == null) return false;

            // Create Google Feed API address
            var api = "http://ajax.googleapis.com/ajax/services/feed/load?v=1.0&callback=?&q=" + rssUrl;
            if (options.limit != null) api += "&num=" + options.limit;
            if (options.key != null) api += "&key=" + options.key;

            // Send request
            $.getJSON(api, function (data) {

                // Check for error
                if (data.responseStatus == 200) {

                    // Process the feeds
                    //_callback(e, data.responseData.feed, options);
                    _callback2(e, data.responseData.feed, options);

                } else {

                    // Handle error if required
                    if (options.showerror)
                        if (options.errormsg != '') {
                            var msg = options.errormsg;
                        } else {
                            var msg = data.responseDetails;
                        };
                    //  $(e).html('<div class="rssError"><p>' + msg + '</p></div>');
                };
            });
        });
    };

    // Callback function to create HTML result
    var _callback = function (e, feeds, options) {
        if (!feeds) {
            return false;
        }
        var html = '';
        var row = 'odd';

        // Add header if required
        if (options.header)
            html += '<div class="rssHeader">' +
				'<a href="' + feeds.link + '" title="' + feeds.description + '">' + feeds.title + '</a>' +
				'</div>';

        // Add body
        html += '<div class="rssBody">' +
			'<ul>';

        // Add feeds
        for (var i = 0; i < feeds.entries.length; i++) {

            // Get individual feed
            var entry = feeds.entries[i];

            // Format published date
            var entryDate = new Date(entry.publishedDate);
            var pubDate = entryDate.toLocaleDateString() + ' ' + entryDate.toLocaleTimeString();

            // Add feed row
            html += '<li class="rssRow ' + row + '">' +
				'<' + options.titletag + '><a href="' + entry.link + '" title="View this feed at ' + feeds.title + '">' + entry.title + '</a></' + options.titletag + '>'
            if (options.date) html += '<div>' + pubDate + '</div>'
            if (options.content) {

                // Use feed snippet if available and optioned
                if (options.snippet && entry.contentSnippet != '') {
                    var content = entry.contentSnippet;
                } else {

                    var content = entry.content;
                }

                html += '<p>' + content + '</p>'
            }

            html += '</li>';

            // Alternate row classes
            if (row == 'odd') {
                row = 'even';
            } else {
                row = 'odd';
            }
        }

        html += '</ul>' +
			'</div>'

        $(e).html(html);
    };
    var ONE_DAY = 1000 * 60 * 60 * 24;
    var _callback2 = function (e, feeds, options) {
        var html = "";
        for (var i = 0; i < feeds.entries.length; i++) {
            var entry = feeds.entries[i];
            $("#helpdiv").html(entry.content);
            if ($("#helpdiv img:last").length > 0) {
                var imgsrc = $("#helpdiv img:last").attr("src");
            }
            else {
                var imgsrc = "img/rss_feed_icon.jpg";
            }
            // Format published date
            var entryDate = new Date(entry.publishedDate);
            var pubDate = entryDate.toLocaleDateString() + ' ' + entryDate.toLocaleTimeString();
            // Convert both dates to milliseconds
            var pubDateMS = new Date(entry.publishedDate).getTime();
            var todayMS = new Date().getTime();

            // Calculate the difference in milliseconds
            var difference_ms = Math.abs(todayMS - pubDateMS)

            // Convert back to days and return
            var deffDay = parseInt(difference_ms / ONE_DAY);

            //html += '<li class="clearfix"><img src="' + imgsrc + '" title="" alt="" class="pic" width="159" height="99" />';
            //html += '<h2><span class="logo' + rss_logos[rssId] + ' logos"><!----></span></h2>';
            html += '<a href="' + entry.link + '" title="">' + entry.title + '</a>'; //</li>
            html += '<br/><br/><span>'+deffDay+' Days Ago</span>';
        }
        $(e).html($(e).html() + html);
        //setHeight();

        //        $("IMG").each(function (index, obj) {
        //            alert($(obj).attr("src"));
        //        });

        //        $(e).remove();
        //    //    $("IMG").css("display", "none");

    };
})(jQuery);
