<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolJson.aspx.cs" Inherits="YouTong.WebSite.Datas.SchoolJson" %>
<%@ OutputCache VaryByParam="none" Duration="300" %>

var schoolJson=<%= json %>;

function getSchools(regionId) {
	var arr = new Array();
	for(i=0;i<schoolJson.length;i++) {
		if(schoolJson[i].Region == regionId) {
			arr.push(schoolJson[i]);
		}
	}
	return arr;
}