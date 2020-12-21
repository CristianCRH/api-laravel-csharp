<?php

use App\Models\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\AuthController;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

/*Route::middleware('auth:api')->get('/user', function (Request $request) {
    return $request->user();
});*/

Route::get("productos", function () {
    $products = [
        "id" => "1",
        "name" => "CABLE UTP",
    ];
    return response()->json($products);
});

Route::get("productos/{category_id}", function ($category_id) {
    $products = [
        "id" => "".$category_id,
        "name" => "BY cATEGORY",
    ];
    return response()->json($products);
});

Route::group(['prefix' => 'auth'], function () {
    Route::post('login',  [AuthController::class, 'login']);
    Route::post('register', [AuthController::class, 'register']);

    // Las siguientes rutas además del prefijo requieren que el usuario tenga un token válido
    Route::group(['middleware' => 'auth:api'], function () {
        Route::get('logout',  [AuthController::class, 'logout']);
        Route::get('user',  [AuthController::class, 'user']);
        // Aquí agrega tus rutas de la API. En mi caso (EN MI CASO, EL TUYO PUEDE VARIAR) he agregado una de productos
        Route::get("productos", function () {
            $products = [
                "id" => "1",
                "name" => "CABLE UTP",
            ];
            return response()->json($products);
        });
    });
});
