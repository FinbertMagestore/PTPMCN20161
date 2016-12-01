<!DOCTYPE HTML PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
    <head>
        <title>Admin</title>
        <link rel="shortcut icon" href="" type="image/x-icon" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
        <!--<link rel="stylesheet" href="css/bootstrap-theme.min.css" type="text/css"/>-->
        <link rel="stylesheet" href="{{ $css }}" type="text/css"/>
        <link href="css/reset.css" media="all" rel="stylesheet" type="text/css" />
        <link href="css/boxes.css" media="all" rel="stylesheet" type="text/css" />
        <link href="css/custom.css" media="all" rel="stylesheet" type="text/css" />
        <link href="css/print.css" media="print" rel="stylesheet" type="text/css" />
        <link href="css/menu.css" media="screen, projection" rel="stylesheet" type="text/css" />
        <script src="js/jquery.min.js" type="text/javascript"></script>
        <script src="js/bootstrap.min.js" type="text/javascript"></script>
        <script src="js/jquery.validate.min.js" type="text/javascript"></script>
        <script src="js/jquery.validate.unobtrusive.min.js" type="text/javascript"></script>
        <script src="js/jquery-ui-1.8.17.js" type="text/javascript"></script>
        <script src="/education/resources/assets/content/tiny_mce_v2/jquery.tinymce.js" type="text/javascript"></script>
    </head>
    <body>
        <div id="container">
            @include('templates.include.admin.header')
            <div id="wrapper">
                @yield('content')
            </div>
            @include('templates.include.admin.footer')
        </div>
        <script src="js/owl.carousel.js"></script>
    </body>
</html>