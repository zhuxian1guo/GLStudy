 Shader "Example/Diffuse Simple" {
    SubShader {
      Tags { "RenderType" = "Opaque" } // 标签，决定什么时候渲染（对不透明物体渲染）
      CGPROGRAM // //CG语言标记开始
      #pragma surface surf Lambert // 编译指令 surface shader 自定义函数 光照模型[1] 
      struct Input {               // 输入的结构体
          float4 color : COLOR;    // 颜色值
      };
      void surf (Input IN, inout SurfaceOutput o) { // surface shader处理函数
          o.Albedo = 1;  // 将基础颜色设为白色[2]
      }
      ENDCG
    }
    Fallback "Diffuse" // 发生异常时回滚成Unity内置的Diffuse shader
  }