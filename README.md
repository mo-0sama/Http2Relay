# Http2Relay
Http2Relay is web api .net core project , used as Proxy API, it proxy Http calls to Http2 Calls and retrieve response.

.net framework doesn't support Http2, when deal with http2 third party we found some issues like timeout or lost connection.
so we made this web api .net 5, that support http2 connection, work as Reverse Proxy API but with make second call using http2.
i use it when call api.Apple Push notification api that support Http2 connection.

# Usage
Just Append real url to call like:
    request.Headers.Add("RelayURL", "https://api.sandbox.push.apple.com:443/3/device/devicetoken");