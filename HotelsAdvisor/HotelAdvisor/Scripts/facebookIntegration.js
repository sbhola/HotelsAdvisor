/**
 * [Created global Namespace as window.HotelAdvisor]
 */
window.HotelAdvisor = window.HotelAdvisor || {};

/**
 * [Creating Alias namespace hoteladvisor]
 */
var hoteladvisor = window.HotelAdvisor || {};

/**
 * [Created Singleton class Facebook]
 */
hoteladvisor.Facebook = new (function () {
    /**
     * [getAppId function returns a Facebook App ID]
     *  @return {[String]} Returns Facebook App ID
     */
    this.getAppId = function() {
        return "496081630535082";
    };
    /**
     * [getVersion function returns Version No currently we are using v2.0]
     * @return {[String]} Returns Version No
     */
    this.getVersion = function() { //this function will return version number
        return "v2.0";
    };
    /**
     * [getUserName function will return the Facebook username of the person currently logged in]
     * @return {[String]} Returns response.name through FB.api method 
     */
    this.getUserName = function(userID) {
        FB.api('/' + userID + '?fields=name', function(response) {
            document.getElementById('divUserName').innerHTML = "Welcome " + response.name;
        });
    };

    var self = this;
    /**
     * [initialize function will Load Facebook JS SDK into DOM , After SDK is loaded it will call FB.init method]
     */
    this.initialize = function() {
        (function(d, s, id) {
            //get first script element , use for finding parent
            var js, fjs = d.getElementsByTagName(s)[0];
            //if sdk is already installed ,then we are done
            if (d.getElementById(id)) return;
            //create a new script element and set its id
            js = d.createElement(s);
            js.id = id;
            js.async = true;
            //set source of new element to the source of FB JS SDK
            js.src = "http://connect.facebook.net/en_US/sdk.js#xfbml=1&appId="
                + self.getAppId() + "&version=" + self.getVersion();
            //this will insert FB JS SDK into DOM
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));

        /**
         * [fbAsyncInit will be called by SDK when SDK is completely loaded into DOM]
         */
        window.fbAsyncInit = function() {
            /**
             * [It will check Login Status,if connected then we will get userID]
             */
            FB.getLoginStatus(function(response) {
                if (response.status === 'connected') {
                    var userid = response.authResponse.userID;
                    self.getUserName(userid);
                }
            });
            FB.Event.subscribe('auth.login', function(response) {
                document.getElementById('divUserName').style.display = 'none';
            });
            FB.Event.subscribe('auth.logout', function(response) {
                document.getElementById('divUserName').style.display = 'none';

            });
        };
    };

})();

hoteladvisor.Facebook.initialize();   //call to initialize function
