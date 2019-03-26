# 配置字段类型配置
field_types = {
	"bool":lambda data:get_bool(data),
	"int":lambda data:get_int(data),
	"string":lambda data:get_string(data),
	"float":lambda data:get_float(data),
	"int[]":lambda data:get_int_list(data),
	"string[]":lambda data:get_string_list(data),
	"float[]":lambda data:get_float_list(data),
}

def get_int(data):
	try:
		return int(data)
	except Exception as e:
		print("int类型转换失败！data = "+data)
		raise e

def get_string(data):
	try:
		return str(data)
	except Exception as e:
		print("string类型转换失败！data = "+data)
		raise e

def get_int_list(data):
	try:
		if data == "":
			return []
		data_list = data.split(",")
		for i in range(len(data_list)):
			data_list[i] = int(data_list[i])
		return data_list
	except Exception as e:
		print("int_list类型转换失败！data = "+data)
		raise e

def get_string_list(data):
	try:
		if data == "":
			return []

		data_list = data.split(",")
		return data_list
	except Exception as e:
		print("string_list类型转换失败！data = "+data)
		raise e

def get_float_list(data):
	try:
		if data == "":
			return []

		data_list = data.split(",")
		for i in range(len(data_list)):
			data_list[i] = float(data_list[i])
		return data_list
	except Exception as e:
		raise e

def get_bool(data):
	try:
		return bool(data)
	except Exception as e:
		print("bool类型转换失败！data = "+data)
		raise e

def get_float(data):
	try:
		return float(data)
	except Exception as e:
		print("float类型转换失败！data="+data)
		raise e

# 获取转换后的数据
def get_conv_data(data,data_type):
	return field_types[data_type](data)
