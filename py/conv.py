# excel2json
import field_types_config
import os
import xlrd
import collections
import pprint
import json
import export_template
import shutil
import configparser

# 读取excel配置路径
def read_excels_paths():
	global xls_dir
	books = os.listdir(xls_dir)
	path_list = []
	for name in books:
		path_list.append(xls_dir+name)
	return path_list

# 导出excel
def export_excels(path_list):	
	for path in path_list:
		file_name = os.path.basename(path)
		work_book = xlrd.open_workbook(path)
		# print(work_book.sheet_names())
		for sheet_name in work_book.sheet_names():
			if check_need_export(sheet_name):
				export_sheet(file_name,work_book,sheet_name)
	print("导表完成！")
	pass


# 导出表内容
# 参数说明：文件名，工作簿对象，表名
def export_sheet(file_name,work_book,sheet_name):
	print("开始导出配置:  文件={0},   表={1}".format(file_name,sheet_name))
	sheet = work_book.sheet_by_name(sheet_name)
	# print(sheet.name,sheet.nrows,sheet.ncols)
	# 不符合要求的表格不导出
	if sheet.nrows < 3:
		print("需要导出的配置内容不符合要求，请检查Excel文件: [{0}] 的表: [{1}]!!".format(file_name,sheet_name))
		return
	field_names = sheet.row_values(0)
	field_types = sheet.row_values(1)
	field_notes = sheet.row_values(2)
	# print(field_names)  #字段名
	# print(field_types)  #字段类型
	# print(field_notes)  #字段注释
	data_dict = collections.OrderedDict()
	field_name = ""
	field_type = ""
	for i in range(sheet.nrows):
		# 忽略表头内容
		if i>=3:
			data = collections.OrderedDict()
			for j in range(sheet.ncols):
				field_name = field_names[j]
				field_type = field_types[j]
				data[field_name] = get_conv_value(sheet.cell(i,j).value,field_type) 
			item_key = int(sheet.cell(i,0).value)
			data_dict[item_key] = data
	# pprint.pprint(data_dict)
	save_sheet(data_dict,sheet_name)
	export_templates(sheet_name,field_names,field_types,field_notes)

# 输出模版
def export_templates(sheet_name,field_names,field_types,field_notes):
	# 输出模版文件
	model_dict = {}
	model_dict["model_name"] = get_output_name(sheet_name)
	model_dict["note_name"] = get_output_note_name(sheet_name).replace("@","")
	data_list = []
	if len(field_types) == len(field_names):
		for i in range(len(field_names)):
			item = {}
			item["index"] = i
			item["fieldName"] = field_names[i]
			item["fieldType"] = field_types[i]
			item["noteName"] = field_notes[i]
			data_list.append(item)
		data_list = sorted(data_list,key = lambda item:item["index"])
		model_dict["data_list"] = data_list
		export_template.export_cs(model_dict)
	else:
		print("字段数量和字段类型数量不匹配！")
	

def conv_field_type(field_type):
	if field_type=="float":
		return "double"
	else:
		return field_type

# 保存输出文件
def save_sheet(dataDict,sheet_name):
	with open(os.getcwd()+"/output/json/"+get_output_name(sheet_name)+".json","w",encoding="utf-8") as file:
		# num = len(dataDict)
		# count = 0
		# for item in dataDict.values():
		# 	count += 1
		# 	if count < num:
		# 		file.write(json.dumps(item,ensure_ascii=False)+"\n")
		# 	else:
		# 		file.write(json.dumps(item,ensure_ascii=False))
		for item in dataDict.values():
			file.write(json.dumps(item,ensure_ascii=False)+"\n")
	pass


# 获取转化后的数据
def get_conv_value(value,type):
	return field_types_config.get_conv_data(value,type)
	pass

# 获取输出的文件名
def get_output_name(sheet_name):
	output_name = sheet_name.split("#")[1]
	return output_name

#获取注释名
def get_output_note_name(sheet_name):
	output_name = sheet_name.split("#")[0]
	return output_name

# 是否需要导出
def check_need_export(sheet_name):
	if sheet_name.startswith("@"):
		return True
	else:
		return False

# 清空输出文件夹
def clear_output():
	global output_path
	if os.path.exists(output_path):
		shutil.rmtree(output_path)
	os.mkdir(output_path)
	os.mkdir(output_path+"/cs")		
	os.mkdir(output_path+"/json")		

# 拷贝导出文件到项目目录中
def copy_output():
	global output_path
	print("正在拷贝输出文件到项目..")
	config = configparser.ConfigParser()
	config.read(os.getcwd()+"/config/path.cfg")
	to_cs_path = config.get("project_path","cs_path")
	to_json_path = config.get("project_path","json_path")
	from_cs_path = output_path+"/cs"
	from_json_path = output_path+"/json"
	copy_files(from_cs_path,to_cs_path)
	copy_files(from_json_path,to_json_path)
	print("拷贝完成！")

# 拷贝文件
def copy_files(from_path,to_path):
	from_files = os.listdir(from_path)
	for file in from_files:
		shutil.copy(from_path+"/"+file,to_path+"/"+file)

def main():
	global output_path
	global xls_dir
	output_path = os.getcwd()+"/output"
	xls_dir = os.getcwd()+"/xls/"

	# 清空输出文件夹
	clear_output()
	# 导表
	path_list = read_excels_paths()
	export_excels(path_list)
	# 拷贝到项目
	copy_output()

if __name__ == '__main__':
	main()