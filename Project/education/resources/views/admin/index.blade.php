@extends('templates.layouts.admin')

@section('content')
<script type="text/javascript">
    $(document).ready(function () {
        var currentMenu = "dashboard";
        $(".nav-li").removeClass("active");
        $("#nav-li-" + currentMenu).addClass("active");
    });
</script>
<div id="anchor-content" class="middle">
    <div id="page:main-container">
        <div id="messages"><ul class="messages"></ul></div>
        <div>
            <h1>Hệ thống quản trị education.com</h1>
        </div>
    </div>
</div>
@endsection
