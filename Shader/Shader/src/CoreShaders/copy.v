#version 330 core

// 输入顶点数据
layout(location = 0) in vec3 aPos;      // 顶点位置
// 输出到片段着色器的变量
out vec2 Pos;
out vec2 stand;
uniform vec2 iResolution;
out vec2 screen;

// 顶点着色器主函数
void main() {
    // 设置顶点位置
    gl_Position = vec4(aPos, 1.0);

    // 将纹理坐标传递到片段着色器

    Pos = vec2((aPos.x+1)*iResolution.x/2,(aPos.y+1)*iResolution.y/2);
    stand=vec2(aPos.x,aPos.y);
    screen=iResolution;
}