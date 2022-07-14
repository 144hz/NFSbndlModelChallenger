# NFS BNDL Model Challenger 使用教程/Tutorial

极品飞车Most Wanted(2012)车辆模型导入工具，需要NFSbndlRepacker解包/打包BNDL文件 (https://github.com/144hz/NFSbndlRepacker)  
Need for Speed Most Wanted (2012) vehicle model tool, require NFSbndlRepacker to unpack/repack the BNDL file.

样例文件blender+obj下载地址 / blender project example + output obj:  
https://mega.nz/file/bEFmVB5a#HPFk80gaPnkH1rQveBBQzKGRHwqpgDc23vM9qs5x-Q8

## 中文版

### 1.   Blender制作模型

(1) NBMC支持以下几种材质：{metal, carbon, glass, light, interior, tmask}，Blender中object名称的前半部分应从以上选择，NBMC将以此生成材质，如图所示。  
![Blender_screenshot](https://github.com/144hz/NFSbndlModelChallenger/blob/master/tutorial_images/1.jpg)

(2) 材质具体要求： 

材质 | Blender object名称 | dds贴图(DXT5) | 备注
---------- | -------------------------- | ------------------------- | -----------
metal | metal_name | 与object名称相同 | 贴图透明区域为车漆颜色
carbon | carbon_name | 与object名称相同 | 贴图透明区域为黑色
glass | glass_ARGB | 不支持 | 命名格式如glass_80F0C040，透明通道A越大，玻璃越不透明
light | light_ARGB | 与object名称相同 | 命名格式如light_FF00FF80，A无意义，RGB代表头灯颜色
interior | interior_name | 与object名称相同 | 贴图透明通道不生效
tmask | tmask_name | 与object名称相同 | 贴图遮罩，贴图透明区域则模型也为透明

Light材质贴图的作用：贴图alpha通道指示后灯亮度(红色)，贴图red通道指示刹车灯亮度(红色)，贴图green通道指示头灯亮度(由object名称RGB决定)，贴图blue通道指示倒车灯亮度(白色)

(3) 导出模型： 把blender脚本blender_export_obj_NBMC复制到Blender\3.1\scripts\addons_contrib\，并在blender插件中启用

a.  贴图导出为dds格式，保存在obj模型同一文件夹内，名称和对应object名称相同，不需要mtl文件。  
b.  建议使用blender NBMC脚本导出obj，若用其它软件导出模型，应满足如下要求（blender NBMC脚本会自动完成这些工作）  
c.  仅使用三角面和凸多边形面，使用其它软件需手动完成Split Concave Faces .  
d.  顶点座标，uv座标，法线向量一一对应。即导出obj的面格式为( f  1/1/1 2/2/2 3/3/3).

### 2.   NBMC导入模型

(1) 图中两个路径分别为BNDLRepacker解包所得的文件夹和导出的obj模型。点击转换模型会把obj模型和dds贴图导入解包车辆文件夹内。  
若NBMC在导入模型时未在obj所在文件夹下找到object name同名dds贴图，将替代导入默认贴图。  
![NBMC_screenshot](https://github.com/144hz/NFSbndlModelChallenger/blob/master/tutorial_images/2.jpg)

(2) 外观定位可以修改车轮位置和驾驶员位置。  
![NBMC_screenshot](https://github.com/144hz/NFSbndlModelChallenger/blob/master/tutorial_images/3.jpg)

(3) NBMC转换完成后，把修改过的车辆文件夹拖入BNDLRepacker，打包生成的BNDL车辆文件。

<br><br>

## English Version

### 1.	Export model with Blender
(1)	NBMC supports the following materials: {metal, carbon, glass, light, interior, tmask}. The first half of the object name in Blender should be selected from the above, NBMC will generate the material from this, as shown.  
![Blender_screenshot](https://github.com/144hz/NFSbndlModelChallenger/blob/master/tutorial_images/1.jpg)

(2)	Material requirements: 

Material type | Blender object name | dds texture (DXT5) | Note
---------- | -------------------------- | ------------------------- | -----------
metal | metal_name | same as object name | texture transparent area is the paint color
carbon | carbon_name | same as object name | texture transparent area is black
glass | glass_ARGB | no texture | The naming format is like glass_80F0C040，the larger the alpha channel value, the more opaque the glass
light | light_ARGB | same as object name | The naming format is like light_FF00FF80，alpha channel does not take effect, RGB represents the color of the headlight
interior | interior_name | same as object name | texture alpha channel does not take effect
tmask | tmask_name | same as object name | texture mask, the model in texture transparent area is transparent

Texture of Light material: the alpha channel of the texture indicates the brightness of rear lights (red), the red channel of the texture indicates the brightness of brake lights (red), the green channel of the texture indicates the brightness of headlights (determined by the object name RGB), and the blue channel of the texture indicates the brightness of reversing lights (white)

(3)	Export the model: Copy the blender script “blender_export_obj_NBMC” to Blender\3.1\scripts\addons_contrib\ and enable it in the blender plugin

a.	Export the texture to dds format, save it in the same folder of the obj model, the name is the same as the corresponding object name, mtl file doesn't work.
b.	It is recommended to use the blender NBMC script to export the obj model. If you use other software to export, the following requirements should be met (the blender NBMC script will automatically complete these tasks)
c.	Use only triangular and convex polygon faces, split Concave Faces needs to be done manually in other software.
d.	Vertex coordinates, uv coordinates, and normal vectors should be in one-to-one correspondence. That is, the surface format of the exported obj is (f 1/1/1 2/2/2 3/3/3).

### 2.	Import model using NBMC

(1)	The two paths in the figure are the folder unpacked by BNDLRepacker and the exported obj model. Clicking “Transform” will import the obj model and dds texture into the unpacked vehicle folder.  
If NBMC does not find the dds texture with the same name as the object name in the folder where the obj is located, it will use the default texture.  
![NBMC_screenshot](https://github.com/144hz/NFSbndlModelChallenger/blob/master/tutorial_images/2.jpg)

(2)	In Position Adjustment interface, you can modify position of wheels and driver.  
![NBMC_screenshot](https://github.com/144hz/NFSbndlModelChallenger/blob/master/tutorial_images/3.jpg)

(3)	When NBMC transform is complete，drag the unpacked folder to BNDLRepacker to repacked BNDL file.
