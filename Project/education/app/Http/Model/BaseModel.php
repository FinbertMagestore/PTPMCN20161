<?php

namespace App;

class BaseModel extends Model                      
{
    protected $fillable = [
        'name', 'email', 'password',
    ];

}
