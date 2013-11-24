if(!jQuery.parseNumber)
/*! 
* Note:  Microsoft Corporation is not the original author of this script 
* file. Microsoft obtained the original file from 
* http://plugins.jquery.com/project/numberformatter under the license that is referred 
* to below. That license and the other notices below are provided for 
* informational purposes only and are not the license terms under which 
* Microsoft distributes the file.  Microsoft grants you the right to use the 
* file solely to interact through your browser with the Microsoft web site 
* hosting the file, subject to that web site�s terms of use. Unless 
* applicable law gives you more rights, Microsoft reserves all other rights 
* and grants no additional rights, whether by implication, estoppel or 
* otherwise. 
* 
* jquery.numberformatter - Formatting/Parsing Numbers in jQuery 
* Written by Michael Abernethy (mike@abernethysoft.com) 
* 
* Originally obtained under the MIT License. 
* 
* Date: 1/26/08 
* 
* @author Michael Abernethy 
* @version 1.1.0 
* 
* MIT License 
* 
* Permission is hereby granted, free of charge, to any person obtaining 
* a copy of this software and associated documentation files (the 
* "Software"), to deal in the Software without restriction, including 
* without limitation the rights to use, copy, modify, merge, publish, 
* distribute, sublicense, and/or sell copies of the Software, and to 
* permit persons to whom the Software is furnished to do so, subject to 
* the following conditions: 
* 
* The above copyright notice and this permission notice shall be 
* included in all copies or substantial portions of the Software. 
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
* NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE 
* LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
* OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION 
* WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
**/
(function(n){function i(n,t,i){this.dec=n,this.group=t,this.neg=i}function t(n){var r=".",t=",",u="-";return n=="us"||n=="ae"||n=="eg"||n=="il"||n=="jp"||n=="sk"||n=="th"||n=="cn"||n=="hk"||n=="tw"||n=="au"||n=="ca"||n=="gb"||n=="in"?(r=".",t=","):n=="de"||n=="vn"||n=="es"||n=="dk"||n=="at"||n=="gr"||n=="br"?(r=",",t="."):n=="cz"||n=="fr"||n=="fi"||n=="ru"||n=="se"?(t=" ",r=","):n=="ch"&&(t="'",r="."),new i(r,t,u)}n.formatNumber=function(i,r){var r=n.extend({},n.fn.parse.defaults,r),f=t(r.locale.toLowerCase()),o=f.dec,s=f.group,e=f.neg,u=new String(i);return u=u.replace(".",o).replace("-",e)},n.fn.parse=function(i){var i=n.extend({},n.fn.parse.defaults,i),r=t(i.locale.toLowerCase()),e=r.dec,f=r.group,s=r.neg,o="1234567890.-",u=[];return this.each(function(){var t=new String(n(this).text()),h,c,r,i;for(n(this).is(":input")&&(t=new String(n(this).val()));t.indexOf(f)>-1;)t=t.replace(f,"");for(t=t.replace(e,".").replace(s,"-"),h="",c=!1,t.charAt(t.length-1)=="%"&&(c=!0),r=0;r<t.length;r++)o.indexOf(t.charAt(r))>-1&&(h=h+t.charAt(r));i=new Number(h),c&&(i=i/100,i=i.toFixed(h.length-1)),u.push(i)}),u},n.fn.format=function(i){var i=n.extend({},n.fn.format.defaults,i),f=t(i.locale.toLowerCase()),e=f.dec,r=f.group,u=f.neg,o="0#-,.";return this.each(function(){var p=new String(n(this).text()),c,nt,v,s,f,it,tt,w,l,a,d,g,b,t;for(n(this).is(":input")&&(p=new String(n(this).val())),c="",nt=!1,t=0;t<i.format.length;t++)if(o.indexOf(i.format.charAt(t))==-1)c=c+i.format.charAt(t);else if(t==0&&i.format.charAt(t)=="-"){nt=!0;continue}else break;for(v="",t=i.format.length-1;t>=0;t--)if(o.indexOf(i.format.charAt(t))==-1)v=i.format.charAt(t)+v;else break;for(i.format=i.format.substring(c.length),i.format=i.format.substring(0,i.format.length-v.length);p.indexOf(r)>-1;)p=p.replace(r,"");if(s=new Number(p.replace(e,".").replace(u,"-")),v=="%"&&(s=s*100),f="",it=s%1,i.format.indexOf(".")>-1){var k=e,y=i.format.substring(i.format.lastIndexOf(".")+1),h=new String(it.toFixed(y.length));for(h=h.substring(h.lastIndexOf(".")+1),t=0;t<y.length;t++)if(y.charAt(t)=="#"&&h.charAt(t)!="0"){k+=h.charAt(t);continue}else if(y.charAt(t)=="#"&&h.charAt(t)=="0")if(tt=h.substring(t),tt.match("[1-9]")){k+=h.charAt(t);continue}else break;else y.charAt(t)=="0"&&(k+=h.charAt(t));f+=k}else s=Math.round(s);if(w=Math.floor(s),s<0&&(w=Math.ceil(s)),l="",w==0)l="0";else for(a="",a=i.format.indexOf(".")==-1?i.format:i.format.substring(0,i.format.indexOf(".")),d=new String(Math.abs(w)),g=9999,a.lastIndexOf(",")!=-1&&(g=a.length-a.lastIndexOf(",")-1),b=0,t=d.length-1;t>-1;t--)l=d.charAt(t)+l,b++,b==g&&t!=0&&(l=r+l,b=0);f=l+f,s<0&&nt&&c.length>0?c=u+c:s<0&&(f=u+f),i.decimalSeparatorAlwaysShown||f.lastIndexOf(e)==f.length-1&&(f=f.substring(0,f.length-1)),f=c+f+v,n(this).is(":input")?n(this).val(f):n(this).text(f)})},n.fn.parse.defaults={locale:"us",decimalSeparatorAlwaysShown:!1},n.fn.format.defaults={format:"#,###.00",locale:"us",decimalSeparatorAlwaysShown:!1}})(jQuery),function(n,t,i){var v,b,p,w,tt,rt,nt,y,k,g,d,s,l,it,e,h,u,f,a=Array.prototype.slice,o=function(n,t){return function(){return n.apply(t,arguments)}},ut=Object.prototype.hasOwnProperty,c=function(n,t){function r(){this.constructor=n}for(var i in t)ut.call(t,i)&&(n[i]=t[i]);return r.prototype=t.prototype,n.prototype=new r,n.__super__=t.prototype,n};e=n.console,typeof e=="undefined"&&(h=function(){},e={log:h,warn:h,assert:h,clear:h,dir:h,error:h,info:h,profile:h,profileEnd:h}),u={achievementsEarned:"Achievements Earned",avatar:"Avatar of ${DisplayName}",header:{},recentAchievements:"Recent Achievements",recognitionPoints:"Points",learnHow:"No Achievements Earned. <a>Learn How!</a>",learnHowLink:function(){var n;return n='<a href="http://${$item.settings.brand}.microsoft.com/ff395928.aspx#How_do_I_earn_achievements" class="profile-usercard-profileLink" target="_blank">',u.learnHow.replace("<a>",n)},leaderboardEmpty:"No leaderboard results available at this time.",viewProfile:"View Profile"},u.header["all time"]="all time",u.header.day="last day",u.header.days="last %d days",u.header.hour="last hour",u.header.hours="last %d hours",u.header.week="last week",u.header.weeks="last %d weeks",u.header["activities completed"]="activities completed",u.header["points earned"]="points earned",u.achievementsEarned="Achievements Earned",u.avatar="Avatar of ${DisplayName}",u.learnHow="No Achievements Earned. <a>Learn How!</a>",u.recentAchievements="Recent Achievements",u.recognitionPoints="Points",u.viewProfile="View Profile",u.header["all time"]="all time",u.header.day="last day",u.header.days="last %d days",u.header.hour="last hour",u.header.hours="last %d hours",u.header.week="last week",u.header.weeks="last %d weeks",u.header["activities completed"]="activities completed",u.header["points earned"]="points earned",u.leaderboardEmpty="No leaderboard results available at this time.",f={animationSpeed:100,brand:"msdn",host:n.location.host,lang:"en",largeImageDimension:135,leaderboardDataUri:"/v1/leaderboard/",scanDelay:250,search:"",statGroupDataUri:"/v1/statGroup/",userDataUri:"/v1/user/usercard/",userDataBatchSize:50,widgetImageUri:"/v1/resources/widget.png",hideDelay:250,showDelay:750,version:"debug"},f.brand="msdn",f.lang="en-US",f.host="widgets.membership.s-msft.com:80",f.search="?brand=msdn&lang=en-US&_=1364873045393&ver=4.9.0.0",f.version="4.9.0.0",s={resolve:function(t){return n.location.protocol+"//"+f.host+t},resolveStatic:function(n){return this.resolve(n)+f.search},createDataUri:function(){var n,t;return n=arguments[0],t=2<=arguments.length?a.call(arguments,1):[],n=""+s.resolve(n)+(t!=null?t.sort().join(","):void 0),n+("?lang="+f.lang+"&brand="+f.brand)},createQSDataUri:function(){var n,t;return n=arguments[0],t=2<=arguments.length?a.call(arguments,1):[],n=""+s.resolve(n)+"?id="+(t!=null?t.sort().join(","):void 0),n+("&lang="+f.lang+"&brand="+f.brand)},createStatGroupDataUri:function(n,t,i){var r;return r=s.createDataUri(f.statGroupDataUri,n),r+("&filterLocale="+t+"&filterUserId="+i)},createUsercardDataUri:o(function(){var n;return n=1<=arguments.length?a.call(arguments,0):[],s.createQSDataUri(f.userDataUri,n)},this),createLeaderboardDataUri:o(function(){var n;return n=1<=arguments.length?a.call(arguments,0):[],s.createDataUri(f.leaderboardDataUri,n)},this),createWidgetImageUri:function(){return s.resolve(f.widgetImageUri+"?v="+f.version)}},p={scaleImage:function(n,t){var r,f,u;return r=i(n),f={x:r.width(),y:r.height()},u=this.getXDimension(f,t),r.css("width",u),r.css("display","inline-block")},getXDimension:function(n,t){var r,i;return n.x<=t&&n.y<=t?n.x:(i=n.x>=n.y?n.x:n.y,r=t/i,Math.floor(n.x*r))}},d={ellipsify:function(n,t){return n.length<=t?n:(e.log("ellipsify"),n.substr(0,t-3).concat("..."))}},v=function(){function n(n,t,i,r,u){this.dataIdName=n,this.inline=t,this.selector=i,this.template=r,this.templateName=u,this.warn}return n.prototype.canonicalizeId=function(n){return n.replace(/[^a-zA-Z0-9]/g,"").toLowerCase()},n.prototype.findIds=function(n){var e,u,t,o,r,s,f;for(u=[],f=i(this.selector,n),r=0,s=f.length;r<s;r++)o=f[r],e=i(o).attr(this.dataIdName),e?(t=this.canonicalizeId(e),i(o).attr(this.dataIdName,t),i.inArray(t,u)===-1&&u.push(t)):this.warn('Missing required attribute "'+this.dataIdName+'"');return u},n.prototype.onDataLoaded=function(){return this.abstractWarn()},n.prototype.showAll=function(){return this.abstractWarn()},n.prototype.showWidget=function(){return this.abstractWarn()},n.prototype.abstractWarn=function(){return this.warn("You must implement this abstract class method.")},n.prototype.warn=function(n){return e.warn("Profile [BaseWidgetRegistration]: "+n)},n}(),l=function(){function n(n,t,r,u,f){this.dataIdName=n,this.inline=t,this.selector=r,this.template=u,this.templateName=f,this.foundIds=[],i.template(this.templateName,this.template)}return c(n,v),n.prototype.onDataLoaded=function(n){var t;return t=this,i(""+this.selector+"[data-profile-usercard-customLink]").each(function(){var u,r;return u=i(this).attr("data-profile-usercard-customLink"),r=i(this).attr("data-profile-userid"),t.setCustomLink(n,r,u)})},n.prototype.setCustomLink=function(n,t,r){if(n&&n[t])try{n[t].customLink=i.parseJSON(r)}catch(u){e.warn("Profile [UsercardRegistration]: Invalid JSON in data-profile-usercard-customLink")}else e.warn("Profile [UsercardRegistration]: Failed to set custom link; user does not exist in data")},n.prototype.showAll=function(n){return i(this.selector).each(o(function(t,i){return this.showWidget(i,n)},this))},n.prototype.showWidget=function(n,t){var r,s,u,f,o;if(r=i(n),r.length===0&&e.warn("Profile [UsercardRegistration]: Widget not found in DOM"),o=typeof r.attr("data-profile-rendered")!="undefined",!o)return f=r.attr(this.dataIdName),f?(u=t(this.dataIdName,f),u?(u.Content=r.html(),u.Rank=r.attr("data-profile-rank"),u.UserId=f,this.inline&&r.html(""),s=i(this.bindTemplate(u)).appendTo(r),r.attr("data-profile-rendered","true")):e.warn("Profile [UsercardRegistration]: Usercard does not exist in data.")):e.warn('Profile [UsercardRegistration]: Expected id in attribute "'+this.dataIdName+'".')},n.prototype.bindTemplate=function(n){var t;return t={settings:f,ellipsify:d.ellipsify,useDataUri:f.supportsDataUri},i.tmpl(this.templateName,n,t)},n.prototype.warn=function(n){return e.warn("Profile [UsercardRegistration]: "+n)},n.prototype.usercardTemplate='<div class="profile-usercard">            <div class="profile-header">                <span class="profile-userimage">                    {{if $item.useDataUri }}                        <img src="data:image/jpg;base64,${AvatarData}" alt="'+u.avatar+'">                    {{else}}                        <img src="${Avatar}" alt="'+u.avatar+'">                    {{/if}}                </span>                <div>                    <p title="${DisplayName}" class="profile-display-name">${$item.ellipsify(DisplayName, 32)}</p>                {{if Company}}                    <p class="profile-company">${$item.ellipsify(Company, 27)}</p>                {{/if}}                    <p class="profile-affiliations">${Affiliations}</p>                </div>            </div>            <div class="profile-points-bar">                <span class="profile-points">${Points}<span class="points-label"> '+u.recognitionPoints+'</span></span>                <span class="profile-count profile-bronze-points"><span class="profile-bronze-img" title="'+u.achievementsEarned+'"></span><span>${Achievements.Bronze}</span></span>                <span class="profile-count profile-silver-points"><span class="profile-silver-img" title="'+u.achievementsEarned+'"></span><span>${Achievements.Silver}</span></span>                <span class="profile-count profile-gold-points"><span class="profile-gold-img" title="'+u.achievementsEarned+'"></span><span>${Achievements.Gold}</span></span>                        </div>            <div class="profile-achievements-header">                <span class="profile-achievements-title">'+u.recentAchievements+'</span>            </div>            <div class="profile-achievements-recent">                <div class="profile-achievements-centering">                    {{if Achievements.Recent && Achievements.Recent.length > 0}}                        {{each Achievements.Recent}}                    <span class="profile-achievement profile-achievement-${Medal}"><span>${Title}</span></span>                        {{/each}}                    {{else}}                        <div class="profile-achievement-none">'+u.learnHowLink()+'</div>                    {{/if}}                </div>            </div>            <div class="profile-footer">                {{if customLink}}                    <a href="${customLink.href}" title="${customLink.text}" class="profile-usercard-custom-link" target="_blank">${customLink.text}</a>                {{/if}}                <a href="${Profile}?ws=usercard-hover" class="profile-usercard-profileLink" target="_blank">'+u.viewProfile+"</a>            </div>        </div>",n}(),b=function(){function n(){n.__super__.constructor.call(this,"data-profile-userid",!1,".profile-usercard-hover",this.usercardTemplate,"usercardTemplate"),this.canHide=!1,i(this.selector).live("mouseenter",o(function(n){return this.onMouseEnter(n)},this)),i(this.selector).live("mouseleave",o(function(n){return this.onMouseLeave(n)},this))}return c(n,l),n.prototype.onMouseEnter=function(n){var r,u,t;return t=n.currentTarget,r=i(t),r.data("canHide","no"),u=o(function(){if(r.data("canHide")!=="yes")return r.data("data-profile-rendered")||this.showWidget(t,this.getData),i(".profile-usercard",t).fadeIn(f.animationSpeed),this.canHide=!1},this),setTimeout(u,f.showDelay)},n.prototype.onMouseLeave=function(n){var t;return i(n.currentTarget).data("canHide","yes"),this.canHide=!0,t=o(function(){if(i(n.currentTarget).data("canHide")==="yes")return i(".profile-usercard",n.currentTarget).fadeOut(f.animationSpeed)},this),setTimeout(t,f.hideDelay)},n}(),w=function(){function n(){n.__super__.constructor.call(this,"data-profile-userid",!0,".profile-usercard-inline",this.inlineTemplate,"inlineTemplate")}return c(n,l),n.prototype.showWidget=function(t,r){return n.__super__.showWidget.call(this,t,r),i(t).find(".profile-userimage-large > img").bind("load",function(n){return p.scaleImage(n.currentTarget,f.largeImageDimension)}).each(function(){if(this.complete)return p.scaleImage(this,f.largeImageDimension)})},n.prototype.inlineTemplate='<div class="profile-usercard profile-inline">            <div class="profile-inline-header">                <span class="profile-userimage-large">                    <img src="${LargeAvatar}" alt="'+u.avatar+'" />                </span>                <div class="profile-inline-header-details">                    <div title="${DisplayName}" class="profile-inline-display-name">${$item.ellipsify(DisplayName, 32)}</div>            {{if Company}}                    <div class="profile-company profile-inline-secondary">${$item.ellipsify(Company, 27)}</div>            {{/if}}                    <div class="profile-affiliations profile-inline-secondary">${Affiliations}</div>            {{if Website}}                    <div class="profile-inline-url profile-inline-secondary">                        <a title="${Website}" href="${Website}" target="_blank">${$item.ellipsify(Website.replace("http://", "").replace("https://", ""), 22)}</a></div>            {{/if}}                </div>            </div>            <div class="profile-statline">                <span class="profile-points">${Points}<span class="points-label"> '+u.recognitionPoints+'</span></span>                <span class="profile-count profile-bronze-points"><span class="profile-bronze-img" title="'+u.achievementsEarned+'"></span><span>${Achievements.Bronze}</span></span>                <span class="profile-count profile-silver-points"><span class="profile-silver-img" title="'+u.achievementsEarned+'"></span><span>${Achievements.Silver}</span></span>                <span class="profile-count profile-gold-points"><span class="profile-gold-img" title="'+u.achievementsEarned+'"></span><span>${Achievements.Gold}</span></span>            </div>                        <div class="profile-biography">{{if Biography}}${Biography}{{/if}}</div>                        <div class="profile-footer">                {{if customLink}}                <a href="${customLink.href}" title="${customLink.text}" target="_blank" class="profile-usercard-custom-link">${customLink.text}</a>                {{/if}}                <a href="${Profile}?ws=usercard-inline" class="profile-usercard-profileLink" target="_blank">'+u.viewProfile+"</a>            </div>        </div>",n}(),rt=function(){function n(){n.__super__.constructor.call(this,"data-profile-userid",!1,".profile-leaderboard-item",this.leaderboardTemplate,"leaderboardTemplate")}return c(n,l),n.prototype.showWidget=function(t,r){var u;return n.__super__.showWidget.call(this,t,r),u=i(t),u.find("div").length>0&&u.show(),u.find(".profile-leaderboard-value").format({format:"+#,###",locale:f.lang}),u.show()},n.prototype.leaderboardTemplate='<div class="profile-leaderboard-container">            <div class="profile-leaderboard-rank">${Rank}</div>            <div class="profile-leaderboard-userimage">            {{if $item.useDataUri }}                <img src="data:image/jpg;base64,${AvatarData}" alt="'+u.avatar+'">            {{else}}                <img src="${Avatar}" alt="'+u.avatar+'">            {{/if}}            </div>            <div class="profile-leaderboard-name profile-usercard-hover" data-profile-userid="${UserId}">                <a href="${Profile}?ws=leaderboard" target="_blank" data-profile-userid="${UserId}">${DisplayName}</a>            </div>            <div class="profile-ie7-envelope"><div class="profile-leaderboard-value">+${Content}</div></div>        </div>',n}(),nt=function(){function n(){n.__super__.constructor.call(this,"data-profile-userid",!1,".profile-usercard-mini",this.miniTemplate,"miniTemplate")}return c(n,l),n.prototype.showWidget=function(t,r){var u,f;if(!i(".profile-mini",t).length)return u=i(t),f=u.html(),u.html(""),n.__super__.showWidget.call(this,t,r),u.find(".profile-mini-content").html(f)},n.prototype.miniTemplate='<div class="profile-mini">            <div class="profile-mini-header">            <div class="profile-mini-userimage">            {{if $item.useDataUri }}                <img src="data:image/jpg;base64,${AvatarData}" alt="'+u.avatar+'">            {{else}}                <img src="${Avatar}" alt="'+u.avatar+'">            {{/if}}            </div>            <div class="profile-mini-container">                <div title="${DisplayName}" class="profile-mini-display-name"><div class="profile-usercard-hover" data-profile-userid="${UserId}"><a href="${Profile}?ws=usercard-mini" target="_blank">${DisplayName}</a></div></div>            {{if Company}}                <div class="profile-mini-company">${$item.ellipsify(Company, 27)}</div>            {{/if}}                <div class="profile-mini-affiliations">                {{if Affiliations}}                    (${Affiliations})                {{/if}}                </div>                <span class="profile-mini-points">${Points}<span class="points-label"> Points</span></span>                </div>                <div class="profile-mini-content">                </div>            </div>        </div>',n}(),tt=function(){function n(){this.dataIdName="data-profile-leaderboard-key",this.selector=".profile-leaderboard",this.foundIds=[],this.headerName="leaderboardHeaderTemplate",this.itemName="leaderboardItemTemplate",this.emptyName="leaderboardEmptyTemplate",i.template(this.headerName,this.leaderboardHeaderTemplate),i.template(this.itemName,this.leaderboardItemTemplate),i.template(this.emptyName,this.leaderboardEmptyTemplate)}return c(n,v),n.prototype.showAll=function(n){return i(this.selector).each(o(function(t,i){return this.showWidget(i,n)},this))},n.prototype.showWidget=function(n,t){var f,a,o,c,y,l,r,s,h,e,v;if(f=i(n),f.attr("data-profile-leaderboard-loaded")){f.profileWidgitize();return}if(f.attr("data-profile-leaderboard-loaded",!0),l=f.attr("data-profile-leaderboard-key"),l){if(o=t(this.dataIdName,l),o!=null&&(r=eval(o.Items),(r!=null?r.length:void 0)>0)){for(y=this.localizeHeader(o.Header),i.tmpl(this.headerName,y).appendTo(n),h=1,s=r[0].RankingColumn,e=0,v=r.length;e<v;e++)c=r[e],a=c.RankingColumn,a!==s&&(h=e+1),s=a,c.Rank=h;i.tmpl(this.itemName,r).appendTo(n),f.profileWidgitize();return}return i.tmpl(this.emptyName,u.leaderboardEmpty).appendTo(n)}return this.warn('Expected key in attribute "'+this.dataIdName+'"')},n.prototype.localizeHeader=function(n){var f,e,r,t,i;try{f=n.match(/points earned|activities completed/)[0],r=n.match(/weeks|week|days|day|hours|hour|all time/)[0],e=(i=n.match(/\d+/))!=null?i[0]:void 0,t=u.header[f]+" - "+u.header[r].replace(/%d/,e)}catch(o){leaderboard.warn("failed to load leaderboard header")}return t},n.prototype.onDataLoaded=function(){},n.prototype.leaderboardEmptyTemplate='<div class="profile-leaderboard-empty">${}</div>',n.prototype.leaderboardHeaderTemplate='<div class="profile-leaderboard-header">${}</div>',n.prototype.leaderboardItemTemplate='<div class="profile-leaderboard-item" data-profile-userid="${UserId}" data-profile-rank="${Rank}" style="display: none;">${RankingColumn}</div>',n.prototype.warn=function(n){return e.warn("Profile [Leaderboard]: "+n)},n}(),g=function(){function n(){this.dataIdName="data-profile-statGroupId",this.selector=".profile-statGroup",this.foundIds=[],this.statGroupTemplateName="statGroupTemplate",i.template(this.statGroupTemplateName,this.statGroupTemplate)}return c(n,v),n.prototype.canonicalizeId=function(n){return n.replace(/[^a-zA-Z0-9_\-;]/g,"")},n.prototype.findIds=function(n){var o,e,s,t,u,l,r,f,c,h;for(e=[],h=i(this.selector,n),f=0,c=h.length;f<c;f++)t=h[f],u=l=void 0,u=i(t).attr("data-profile-statGroup-key"),o=i(t).attr("data-profile-filterLocale"),o!=null||(o=""),r=i(t).attr("data-profile-userId"),r!=null||(r=""),u!=null?(s=this.canonicalizeId(u+";"+o+";"+r),i(t).attr(this.dataIdName,s),i.inArray(s,e)===-1&&e.push(s)):this.warn('Missing required attribute(s) "data-profile-statGroup-key"');return e},n.prototype.showAll=function(n){return i(this.selector).each(o(function(t,i){return this.showWidget(i,n)},this))},n.prototype.showWidget=function(n,t){var r,o,u,s;if(r=i(n),r.length===0&&e.warn("Profile [StatGroupWidgetRegistration]: Widget not found in DOM"),s=typeof r.attr("data-profile-rendered")!="undefined",!s)return u=r.attr(this.dataIdName),u!=null?(o=t(this.dataIdName,u),o?(i.tmpl(this.statGroupTemplate,o).appendTo(r),r.attr("data-profile-rendered","true"),r.find(".value").format({format:"#,###",locale:f.lang})):e.warn("Profile [StatGroupWidgetRegistration]: Item does not exist in data.")):e.warn('Profile [StatGroupWidgetRegistration]: Expected id in attribute "'+this.dataIdName+'".')},n.prototype.onDataLoaded=function(){},n.prototype.statGroupTemplate='<div class="statistic-group">            <div class="statistic-header">${Header}</div>            <table class="statistic-table">                <tbody>                    {{each Statistics}}                    <tr>                        <td class="name">${$value.Name}</td>                        <td class="value"><span>${$value.Value}</span></td>                    </tr>                    {{/each}}                </tbody>            </table>        </div>',n}(),y=function(){function n(n,r,u,f){var h,e,c,s;for(this.registeredWidgets=n,this.createDataUri=r,this.jsonpCallbackName=u,this.batch=f!=null?f:!1,this.getData=o(this.getData,this),this.loadDataError=o(this.loadDataError,this),this.loadDataSuccess=o(this.loadDataSuccess,this),this.scannedIds=[],i(t).ajaxComplete(o(function(){return this.scanWhenAble()},this)),s=this.registeredWidgets,e=0,c=s.length;e<c;e++)h=s[e],h.getData=o(function(n,t){return this.getData(n,t)},this)}return n.prototype.scan=function(n){var r,t,u,a,h,o,f,e,l,v,c,s;for(r=[],s=this.registeredWidgets,o=0,l=s.length;o<l;o++)for(a=s[o],h=a.findIds(n),f=0,v=h.length;f<v;f++)t=h[f],i.inArray(t,r)===-1&&r.push(t);if(u=[],this.scannedIds)for(e=0,c=r.length;e<c;e++)t=r[e],i.inArray(t,this.scannedIds)===-1&&(u.push(t),this.scannedIds.push(t));else u=r,this.scannedIds=r;return u.length?this.loadData(u):this.showItems()},n.prototype.scanWhenAble=function(){var n;return this.pending||(n=o(function(){return this.scan(),this.pending=!1},this),setTimeout(n,f.scanDelay)),this.pending=!0},n.prototype.showItems=function(){var r,n,u,t,i;for(t=this.registeredWidgets,i=[],n=0,u=t.length;n<u;n++)r=t[n],i.push(r.showAll(this.getData));return i},n.prototype.loadData=function(n){var t;return this.batch?(t=f.userDataBatchSize,this.currentBatch=this.currentBatch>=0?this.currentBatch+1:0,n.length<=t?this.loadDataAjax(n,this.currentBatch):(this.batch=n.slice(0,t),this.loadDataAjax(this.batch,this.currentBatch),n=n.slice(t,n.length),this.loadData(n))):this.loadDataAjax(n)},n.prototype.loadDataAjax=function(n,t){return i.ajax({url:this.createDataUri(n),dataType:"jsonp",cache:!0,jsonpCallback:this.jsonpCallbackName+(t!=null?t:""),success:this.loadDataSuccess,error:this.loadDataError})},n.prototype.loadDataSuccess=function(n){var u,t,f,r;for(this.data=i.extend(!0,this.data,n),r=this.registeredWidgets,t=0,f=r.length;t<f;t++){u=r[t];u.onDataLoaded(this.data)}return this.showItems()},n.prototype.loadDataError=function(n){return this.warn("Ajax request error: #status, "+n.status+": "+n.statusText)},n.prototype.getData=function(n,t){var i,r;return this.data||this.warn("Unable to load data"),i=(r=this.data)!=null?r[t]:void 0,i&&(i[n]=t),i},n.prototype.warn=function(n){return e.warn("Profile [Scanner]: "+n)},n}(),k=function(){function n(){n.__super__.constructor.apply(this,arguments)}return c(n,y),n.prototype.loadData=function(n){var r,t,u,i;for(i=[],t=0,u=n.length;t<u;t++)r=n[t],i.push(this.loadDataAjax(r));return i},n.prototype.loadDataAjax=function(n){var r;return r=n.split(";"),i.ajax({url:this.createDataUri(r[0],r[1],r[2]),dataType:"jsonp",cache:!0,jsonpCallback:this.jsonpCallbackName,success:this.loadDataSuccess,error:this.loadDataError})},n}(),it=function(){function n(){var u,f,r,n,t;this.detectFeatures(),r=[new w,new rt,new nt,new b],this.usercardScanner=new y(r,s.createUsercardDataUri,"jsonp_loadUserData",!0),f=[new tt],this.leaderboardScanner=new y(f,s.createLeaderboardDataUri,"jsonp_loadLeaderboardData",!1),n=[new g],this.statGroupScanner=new k(n,s.createStatGroupDataUri,"jsonp_loadStatGroupData",!1),t=this.usercardScanner,i.fn.profileWidgitize=function(){return t.scanWhenAble(this),this},this.usercardScanner.scan(),this.leaderboardScanner.scan(),this.statGroupScanner.scan(),u=new Image,u.src=s.createWidgetImageUri()}return n.prototype.detectFeatures=function(){var n;return n=new Image,n.onload=n.onabort=n.onerror=function(){return f.supportsDataUri=this.width===1&&this.height===1},n.src="data:image/gif;base64,R0lGODlhAQABAIABAP8AAP///yH5BAEAAAEALAAAAAABAAEAAAICRAEAOw%3D%3D"},n}(),i(t).ready(function(){return new it})}(this,document,jQuery)