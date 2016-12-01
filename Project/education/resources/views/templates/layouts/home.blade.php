<!DOCTYPE HTML PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
    <head>
        <title>{{ $title }}</title>
        <link rel="shortcut icon" href="" type="image/x-icon" />
        <link rel="image_src" href="{{ $imageSrc }}" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
        <meta content="{{ $description }}" name="description" />
        <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
        <!--<link rel="stylesheet" href="css/bootstrap-theme.min.css" type="text/css"/>-->
        <link rel="stylesheet" href="{{ $css }}" type="text/css"/>
        <script src="js/jquery.min.js" type="text/javascript"></script>
        <script src="js/bootstrap.min.js" type="text/javascript"></script>
    </head>
    <body>
        <div id="container">
            @include('templates.include.home.header')
            <div id="wrapper">
                @yield('content')
            </div>
            @include('templates.include.home.footer')
        </div>
        <script src="js/owl.carousel.js"></script>
    </body>
</html>