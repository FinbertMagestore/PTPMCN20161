<?php

namespace App\Http\Controllers;

use App\Http\Controllers\EducationBaseController;

class AdminController extends EducationBaseController {

    function __construct() {
        parent::__construct();
        $this->css = "admin_default";
        $this->title = "Trang chủ quản trị";
        $this->description = "";
        $this->imageSrc = "";
    }

    public function index() {
        $model = array(
            "css" => $this->Css(),
            "title" =>  $this->Title(),
            "description" => $this->Description(),
            "imageSrc" => $this->ImageSrc()
        );
        return view('admin.index', $model);
    }

}
