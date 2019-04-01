﻿//var applicationServerPublicKey = '';
var serviceWorker = 'sw.js';
subscribe();

function subscribe() {
    navigator.serviceWorker.ready.then(function (reg) {
        var subscribeParams = { userVisibleOnly: true };

        //Setting the public key of our VAPID key pair.
        var applicationServerKey = urlB64ToUint8Array(applicationServerPublicKey);
        subscribeParams.applicationServerKey = applicationServerKey;

        reg.pushManager.subscribe(subscribeParams)
            .then(function (subscription) {
                isSubscribed = true;

                var p256dh = base64Encode(subscription.getKey('p256dh'));
                var auth = base64Encode(subscription.getKey('auth'));

                console.log(subscription);

                $('#PushEndpoint').val(subscription.endpoint);
                $('#PushP256DH').val(p256dh);
                $('#PushAuth').val(auth);
            })
            .catch(function (e) {
                errorHandler('[subscribe] Unable to subscribe to push', e);
            });
    });
}

function errorHandler(message, e) {
    if (typeof e === 'undefined') {
        e = null;
    }

    console.error(message, e);
    $("#errorMessage").append('<li>' + message + '</li>').parent().show();
}

function urlB64ToUint8Array(base64String) {
    var padding = '='.repeat((4 - base64String.length % 4) % 4);
    var base64 = (base64String + padding)
        .replace(/\-/g, '+')
        .replace(/_/g, '/');

    var rawData = window.atob(base64);
    var outputArray = new Uint8Array(rawData.length);

    for (var i = 0; i < rawData.length; ++i) {
        outputArray[i] = rawData.charCodeAt(i);
    }
    return outputArray;
}

function base64Encode(arrayBuffer) {
    return btoa(String.fromCharCode.apply(null, new Uint8Array(arrayBuffer)));
}