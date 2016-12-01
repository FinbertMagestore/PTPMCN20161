<div class="header">
    <div class="header-top">
        <h1 style="float:left;padding-left:20px;"><a href="/admin" style="text-decoration:none;">Quản trị hệ thống</a></h1>
        <div class="header-right">
            <p class="super">
                Xin chào xuannt@gmail.com <span class="separator">
                    | </span>01/12/2016 8:44:08 CH<span class="separator">
                    |</span> <a class="link-logout" href="">Đăng xuất</a>
            </p>
        </div>
    </div>
    <div class="nav-bar">
        <ul id="nav">
            <li id="nav-li-dashboard" class="level0 nav-li active">
                <a href="/education/admin/dashboard"><span>Trang chủ</span></a>
            </li>  
            <li id="nav-li-category" class="level0 nav-li" onmouseout="$(this).removeClass('over')" onmouseover="$(this).addClass('over')">
                <a href="#" onclick="return false;"><span>Chuyên mục</span></a>
                <ul>              
                    <li class="level1"><a href="/admin/categories"><span>Danh sách danh mục</span></a></li>
                </ul>        
            </li>
            <li id="nav-li-lession" class="level0 nav-li" onmouseout="$(this).removeClass('over')" onmouseover="$(this).addClass('over')">
                <a href="#" onclick="return false;"><span>Bài giảng</span></a>
                <ul>              
                    <li class="level1"><a href="/admin/lessions"><span>Danh sách bài giảng</span></a></li>
                </ul>        
            </li>
            <li id="nav-li-user" class="level0 nav-li" onmouseout="$(this).removeClass('over')" onmouseover="$(this).addClass('over')">
                <a href="#" onclick="return false;"><span>Người dùng</span></a>
                <ul>              
                    <li class="level1"><a href="/admin/clients"><span>Danh sách người dùng</span></a></li>
                </ul>        
            </li>
            <li id="nav-li-system" class="level0 nav-li" onmouseout="$(this).removeClass('over')" onmouseover="$(this).addClass('over')">
                <a href="#" onclick="return false;"><span>Hệ thống</span></a>        
                <ul>
                    <li class="level1">
                        <a href="/admin/reports"><span>Danh sách báo cáo</span></a>
                    </li>
                    <li class="level1">
                        <a href="/admin/feedbacks" target="_blank"><span>Danh sách phản hồi</span></a>
                    </li>   
                    <li class="parent level1" onmouseout="$(this).removeClass('over')" onmouseover="$(this).addClass('over')">
                        <a href="/admin/systemsetting"><span>Phân quyền</span></a>
                        <ul>
                            <li class="level2"><a href="/admin/users"><span>Tài khoản hệ thống</span></a></li>
                            <li class="level2"><a href="/admin/roles"><span>Vai trò</span></a></li>
                        </ul>
                    </li>    
                </ul>
            </li>
        </ul>
    </div>
</div>