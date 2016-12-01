<?php

namespace App\Http\Controllers;

use App\Http\Controllers\EducationBaseController;

class HomeController extends EducationBaseController {

    function __construct() {
        parent::__construct();
        $this->css = "default";
        $this->title = "Trang chủ";
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
        return view('home.index', $model);
    }

}
