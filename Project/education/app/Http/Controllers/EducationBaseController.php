<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;

class EducationBaseController extends Controller {

    private $title;
    private $css;
    private $domainName;
    private $description;
    private $imageSrc;

    function __construct() {
        $this->domainName = "http://localhost:5050/education/public/";
    }

    public function __get($property) {
        if (property_exists($this, $property)) {
            return $this->$property;
        }
    }

    public function __set($property, $value) {
        if (property_exists($this, $property)) {
            $this->$property = $value;
        }

        return $this;
    }

    /**
     * get foler sass
     * return
     */
    protected function Css() {
        return "../resources/assets/sass/dist/" . $this->css . ".css";
    }

    protected function Title() {
        return $this->title;
    }

    protected function DomainName() {
        return $this->domainName;
    }

    protected function Description() {
        return $this->description;
    }

    protected function ImageSrc() {
        return $this->imageSrc;
    }

}
