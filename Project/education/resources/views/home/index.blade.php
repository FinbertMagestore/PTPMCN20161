@extends('templates.layouts.home')
@section('content')
<div class="banner">
    <div class="container">
        <h1 class="title-1">Giúp trao đổi tài liệu,<br/> thông tin học tập dễ dàng</h1>
    </div>
</div>
<div class="search">
    <div class="container">
        <div class="row">
            <div class="col-xs-8">
                <input class="input-registration" placeholder="Nhập từ khóa tìm kiếm" type="text">
            </div>
            <div class="col-xs-4">
                <a href="#" class="btn-registration">Tìm kiếm</a>
            </div>
        </div>
    </div>
</div>
<div class="page-1">
    <div class="container">
        <div class="row">
            <div class="col-xs-3 col-xs-offset-2">
                <div class="box">
                    <img src="../resources/assets/images/index/category.png"/>
                    <div class="box-content">
                        <h3 class="title-2">
                            <a href="/chuyen-muc">Chuyên mục</a>
                        </h3>
                        <p class="title-3">33 chuyên mục</p>
                    </div>
                </div>
            </div>
            <div class="col-xs-3 col-xs-offset-1">
                <div class="box">
                    <img src="../resources/assets/images/index/lession.png"/>
                    <div class="box-content">
                        <h3 class="title-2">
                            <a href="/bai-giang">Bài giảng</a>
                        </h3>
                        <p class="title-3">150 bài giảng</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="page-2">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h2 class="title-2">Bài giảng (mới nhất)</h2>
                <table>
                    <tbody>
                        <tr class="lession">
                            <td colspan="4">Tên</td>
                            <td colspan="2">Giáo viên</td>
                            <td colspan="1">Môn</td>
                            <td colspan="1">Ngày đăng</td>
                        </tr>
                        <tr class="sub-lession">
                            <td colspan="4">
                                <a href="/" class="title-3">Ghi nhớ nhanh</a>
                                <p class="category-description">Giới thiệu kinh nghiệm học tập cho học sinh</p>
                            </td>
                            <td colspan="2">
                                <p class="user-post">huynv</p>
                                <p class="user-fullname">Nguyễn Thị Xuân</p>
                            </td>
                            <td colspan="1">
                                <p>Toán</p>
                            </td>
                            <td colspan="1">
                                <span class="time">08-18-2016, 10:39 AM</span>
                            </td>
                        </tr>
                        <tr class="sub-lession">
                            <td colspan="4">
                                <a href="/" class="title-3">Ghi nhớ nhanh</a>
                                <p class="category-description">Giới thiệu kinh nghiệm học tập cho học sinh</p>
                            </td>
                            <td colspan="2">
                                <p class="user-post">huynv</p>
                                <p class="user-fullname">Nguyễn Thị Xuân</p>
                            </td>
                            <td colspan="1">
                                <p>Toán</p>
                            </td>
                            <td colspan="1">
                                <span class="time">08-18-2016, 10:39 AM</span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
<div class="page-3">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h2 class="title-2">Chuyên mục</h2>
                <?php $index = 1 ?>
                <table>
                    <tbody>
                        <tr class="divider category<?php echo $index ?>">
                            <td colspan="5">Kinh nghiệm học tập</td>
                            <td colspan="1">Bài viết</td>
                            <td colspan="2">
                                Bài cuối
                            </td>
                            <td colspan="1">
                                <i class="fa fa-angle-down hide"></i>
                                <i class="fa fa-angle-up"></i>
                            </td>
                        </tr>
                        <tr class="sub-category<?php echo $index ?>">
                            <td colspan="5">
                                <a href="/" class="title-3">Ghi nhớ nhanh</a>
                                <p class="category-description">Giới thiệu kinh nghiệm học tập cho học sinh</p>
                            </td>
                            <td colspan="1">179</td>
                            <td colspan="2">
                                <a href="/" class="title-3">10 phút nhớ 20 từ mới</a>
                                <p style="margin-bottom: 0;">gửi bởi <span class="user-post">huynv</span></p>
                                <p>08-18-2016, 10:39 AM</p>
                            </td>
                            <td colspan="1"></td>
                        </tr>
                        <tr class="last-subcategory sub-category<?php echo $index ?>">
                            <td colspan="5">
                                <a href="/" class="title-3">Ghi nhớ nhanh</a>
                                <p class="category-description">Giới thiệu kinh nghiệm học tập cho học sinh</p>
                            </td>
                            <td colspan="1">179</td>
                            <td colspan="2">
                                <a href="/" class="title-3">10 phút nhớ 20 từ mới</a>
                                <p style="margin-bottom: 0;">gửi bởi <span class="user-post">huynv</span></p>
                                <p>08-18-2016, 10:39 AM</p>
                            </td>
                            <td colspan="1"></td>
                        </tr>

                        <?php $index++ ?>
                        <tr class="divider category<?php echo $index ?>">
                            <td colspan="5">Kinh nghiệm học tập</td>
                            <td colspan="1">Bài viết</td>
                            <td colspan="2">Bài cuối</td>
                            <td colspan="1">
                                <i class="fa fa-angle-down"></i>
                                <i class="fa fa-angle-up hide"></i>
                            </td>
                        </tr>
                        <tr class="hidden-row sub-category<?php echo $index ?>">
                            <td colspan="5">
                                <a href="/" class="title-3">Ghi nhớ nhanh</a>
                                <p class="category-description">Giới thiệu kinh nghiệm học tập cho học sinh</p>
                            </td>
                            <td colspan="1">179</td>
                            <td colspan="2">
                                <a href="/" class="title-3">10 phút nhớ 20 từ mới</a>
                                <p style="margin-bottom: 0;">gửi bởi <span class="user-post">huynv</span></p>
                                <p>08-18-2016, 10:39 AM</p>
                            </td>
                            <td colspan="1"></td>
                        </tr>
                        <tr class="hidden-row sub-category<?php echo $index ?>">
                            <td colspan="5">
                                <a href="/" class="title-3">Ghi nhớ nhanh</a>
                                <p class="category-description">Giới thiệu kinh nghiệm học tập cho học sinh</p>
                            </td>
                            <td colspan="1">179</td>
                            <td colspan="2">
                                <a href="/" class="title-3">10 phút nhớ 20 từ mới</a>
                                <p style="margin-bottom: 0;">gửi bởi <span class="user-post">huynv</span></p>
                                <p>08-18-2016, 10:39 AM</p>
                            </td>
                            <td colspan="1"></td>
                        </tr>
                        <tr class="hidden-row last-subcategory sub-category<?php echo $index ?>">
                            <td colspan="5">
                                <a href="/" class="title-3">Ghi nhớ nhanh</a>
                                <p class="category-description">Giới thiệu kinh nghiệm học tập cho học sinh</p>
                            </td>
                            <td colspan="1">179</td>
                            <td colspan="2">
                                <a href="/" class="title-3">10 phút nhớ 20 từ mới</a>
                                <p style="margin-bottom: 0;">gửi bởi <span class="user-post">huynv</span></p>
                                <p class="time">08-18-2016, 10:39 AM</p>
                            </td>
                            <td colspan="1"></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
<script src="/education/resources/assets/js/pages/default.js"></script>
@endsection