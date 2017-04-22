<%@ Page Language="C#" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="_404" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>404</title>
	<script type="text/javascript" src="http://cdn.static.runoob.com/libs/jquery/1.10.2/jquery.min.js"></script>
</head>
<style type="text/css">
	.container {
		font-family: 'Microsoft Yahei';
		text-align: center;
		width: 1000px;
		margin: 50px auto;
	}
	.container img:first-child {
		text-align: center;
		width: 300px;
		height: auto;
		margin: 0 auto;
	}
	.container img:last-child {
		text-align: center;
		width: auto;
		height: 300px;
		margin: 0 auto;
	}
	.container p {
		text-align: center;
		margin: 30px 0;
		font-size: 30px;
		color: #fd974d;
		letter-spacing: 3px;
	}
	.container span {
		margin-top: 20px;
		cursor: pointer;
		text-align: center;
		height: 80px;
		display: block;
		background: url(images/return.png) center no-repeat;
		background-size: auto 80px;
		font-size: 35px;
		line-height: 80px;
		color: #fff;
	}
</style>
<body>
	<div class="container">
		<img src="images/404.png">
		<p>oops,you have got lost</p>
		<img src="images/00.png">
		<span>return</span>
	</div>
</body>
<script>
	$(".container").children("span").click(function(){
		window.location.href="Index.aspx";
	})
</script>
</html>