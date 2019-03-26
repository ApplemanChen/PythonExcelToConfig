# 导出模版
import os,pprint
from tornado import template

# 导出C#模型文件
def export_cs(model_dict):
	template_path = os.getcwd()+"/templates/DRModel.cs.template"
	output_path = os.getcwd()+"/output/cs/DR"+model_dict["model_name"]+".cs"
	with open(template_path,"r",encoding="utf-8") as file:
		t = template.Template(file.read())
	# pprint.pprint(model_dict)
	# 当字段类型为float时，c#代码中自动转化为double,这是因为json在解析float可能是会出现精度丢失，double不会
	# for item in model_dict["data_list"]:
	# 	if item["fieldType"]=="float":
	# 		item["fieldType"]="double"

	s = t.generate(
			note_name = model_dict["note_name"],
			model_name = model_dict["model_name"],
			data_list = model_dict["data_list"]
		).decode()

	with open(output_path,"w",encoding= "utf-8") as file:
		file.write(s)